using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class WorldEngine : MonoBehaviour
{
    private static WorldEngine _i;
    private GameObject player;
    private bool[] signs;
    private PlayerInput pI;
    private Animator camAnim;
    private Animator camAnim2;
    private GameObject sbk;
    private GameObject mxw;
    SoundManager sM;
    SignMenu signMenu;

    private void Awake()
    {
        signs = new bool[20];
        camAnim = GameObject.Find("Cinematique").GetComponent<Animator>();
        camAnim2 = GameObject.Find("Main Camera").GetComponent<Animator>();
        sbk = GameObject.Find("SignBreak");
        mxw = GameObject.Find("MaxiWin");
        player = GameObject.Find("Player");
        sM = player.GetComponent<SoundManager>();
        pI = player.GetComponent<PlayerInput>();
    }

    public static WorldEngine i
    {
        get
        {
            if (_i == null)
            {
                _i = (Instantiate(Resources.Load("WorldEngine")) as GameObject).GetComponent<WorldEngine>();
                //Saving.LoadFile();
            }
            return _i;
        }
    }

    private int count(bool[] array, bool flag)
    {
        int value = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == flag) value++;
        }

        return value;
    }

    public void BreakRuleSign(int idRule)
    {
        _i.signs[idRule] = true;
        GameObject.Find("Canvas").GetComponent<SignMenu>().ActivateSign(idRule);
        StartCoroutine(RuleAnim(idRule));
        Debug.Log(count(_i.signs, true));
        if (count(_i.signs, true) == 20)
        {
            StartCoroutine(MaxiWin(idRule));
        }
    }

    public bool HasRuleBeenBroke(int idRule)
    {
        return(_i.signs[idRule]);
    }

    IEnumerator RuleAnim(int ruleID)
    {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 0;
        Sprite sp = Resources.Load<Sprite>("Sprites/Signs/"+ruleID.ToString());
        sbk.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = sp;
        sbk.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = sp;
        sbk.transform.GetChild(3).gameObject.GetComponent<TextMeshPro>().text = getFullRule(ruleID);
        Debug.Log(Mathf.Sign(sbk.transform.lossyScale.x));
        sbk.transform.localScale = new Vector3(Mathf.Sign(sbk.transform.lossyScale.x)* sbk.transform.localScale.x, 1, 1);
        pI.SwitchCurrentActionMap("Stop");
        camAnim.SetBool("cinematique", true);
        sbk.transform.GetChild(0).gameObject.SetActive(true);
        sbk.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        sbk.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        sbk.transform.GetChild(3).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        sbk.transform.GetChild(4).gameObject.SetActive(true);
        sbk.transform.GetChild(2).GetComponent<Animator>().Play("explode3");
        camAnim.SetBool("cinematique", false);
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        sbk.transform.GetChild(5).GetComponent<ParticleSystem>().Play();
        sM.PlaySound("Explosion");
        camAnim2.Play("shake");
        pI.SwitchCurrentActionMap("Gameplay");
        sbk.transform.GetChild(0).gameObject.SetActive(false);
        sbk.transform.GetChild(1).gameObject.SetActive(false);
        sbk.transform.GetChild(2).gameObject.SetActive(false);
        sbk.transform.GetChild(3).gameObject.SetActive(false);
        sbk.transform.GetChild(4).gameObject.SetActive(false);
    }

    IEnumerator MaxiWin(int ruleID)
    {
        yield return new WaitForSecondsRealtime(8f);
        Time.timeScale = 0;
        mxw.transform.localScale = new Vector3(Mathf.Sign(mxw.transform.lossyScale.x) * mxw.transform.localScale.x, 1, 1);
        pI.SwitchCurrentActionMap("Stop");
        camAnim.SetBool("cinematique", true);
        mxw.transform.GetChild(0).gameObject.SetActive(true);
        mxw.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        mxw.transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        mxw.transform.GetChild(3).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(7f);
        mxw.transform.GetChild(4).gameObject.SetActive(true);
        mxw.transform.GetChild(2).GetComponent<Animator>().Play("explode3");
        camAnim.SetBool("cinematique", false);
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        mxw.transform.GetChild(5).GetComponent<ParticleSystem>().Play();
        sM.PlaySound("Explosion");
        camAnim2.Play("shake");
        pI.SwitchCurrentActionMap("Gameplay");
        mxw.transform.GetChild(0).gameObject.SetActive(false);
        mxw.transform.GetChild(1).gameObject.SetActive(false);
        mxw.transform.GetChild(2).gameObject.SetActive(false);
        mxw.transform.GetChild(3).gameObject.SetActive(false);
        mxw.transform.GetChild(4).gameObject.SetActive(false);
    }

    private string getFullRule(int ruleID)
    {
        switch (ruleID)
        {
            case 0:
                return "DO NOT WALK ON THE GRASS";
            case 1:
                return "DO NOT DIG IN THE TRASH";
            case 2:
                return "DO NOT ENTER";
            case 3:
                return "DO NOT FISH HERE";
            case 4:
                return "DO NOT PICK UP THE FLOWERS";
            case 5:
                return "DO NOT WALK YOUR DOG HERE";
            case 6:
                return "DO NOT TOUCH THE BEAR";
            case 7:
                return "DO NOT TRESPASS";
            case 8:
                return "WET PAINT DO NOT SIT";
            case 9:
                return "DO NOT VANDALIZE THE STATUE";
            case 10:
                return "OUT OF ORDER DO NOT USE";
            case 11:
                return "DO NOT LITTER";
            case 12:
                return "DO NOT FEED THE ANIMALS";
            case 13: //o
                return "DO NOT SMOKE";
            case 14:
                return "DO NOT SWIM HERE";
            case 15:
                return "DO NOT DISTURB";
            case 16: //o
                return "NO FLASH PHOTOGRAPHY";
            case 17: //o
                return "DO NOT CLIMB";
            case 18: //o
                return "DONT BE LOUD IN THE LIBRARY";
            case 19:
                return "PLEASE WAIT IN LINE";
        }
        return "THIS IS A BUG YOURE NOT SUPPOSED TO SEE THIS";
    }

}
