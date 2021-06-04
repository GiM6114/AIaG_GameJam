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
    SoundManager sM;
    SignMenu signMenu;

    private void Awake()
    {
        signs = new bool[20];
        camAnim = GameObject.Find("Cinematique").GetComponent<Animator>();
        camAnim2 = GameObject.Find("Main Camera").GetComponent<Animator>();
        sbk = GameObject.Find("SignBreak");
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

    public void BreakRuleSign(int idRule)
    {
        _i.signs[idRule] = true;
        GameObject.Find("Canvas").GetComponent<SignMenu>().ActivateSign(idRule);
        StartCoroutine(RuleAnim(idRule));
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

    private string getFullRule(int ruleID)
    {
        switch (ruleID)
        {
            case 0:
                return "DO NOT WALK ON THE GRASS";
                break;
            case 8:
                return "DO NOT SIT HERE, WET PAINT";
                break;
        }
        return "DO NOT WALK ON THE GRASS";
    }

}
