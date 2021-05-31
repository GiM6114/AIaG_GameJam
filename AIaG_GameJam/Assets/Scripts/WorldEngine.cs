using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;


public class WorldEngine : MonoBehaviour
{
    private static WorldEngine _i;
    private GameObject player;
    private bool[] signs;
    private PlayerInput pI;
    private Animator camAnim;

    private void Awake()
    {
        signs = new bool[20];
        camAnim = GameObject.Find("Cinematique").GetComponent<Animator>();
        player = GameObject.Find("Player");
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
        StartCoroutine(RuleAnim());
    }

    public bool HasRuleBeenBroke(int idRule)
    {
        return(_i.signs[idRule]);
    }

    IEnumerator RuleAnim()
    {
        /*
        pI.SwitchCurrentActionMap("Stop");
        camAnim.SetBool("cinematique", true);*/
        yield return new WaitForSeconds(0.04f);
    }

}
