using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class WorldEngine : MonoBehaviour
{
    private static WorldEngine _i;
    private bool[] signs;

    private void Awake()
    {
        signs = new bool[20];
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
    }

    public bool HasRuleBeenBroke(int idRule)
    {
        return(_i.signs[idRule]);
    }

}
