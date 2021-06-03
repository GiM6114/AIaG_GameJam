using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChased : MonoBehaviour
{
    [SerializeField] SoundManager sM;
    [System.NonSerialized] public List<GameObject> chasers = new List<GameObject>();

    public void AddChaser(GameObject chaser)
    {
        if(chasers.Count == 0)
        {
            sM.SwitchMusic("ChaseMusic");
        }
        chasers.Add(chaser);
    }

    public void RemoveChaser(GameObject chaser)
    {
        chasers.Remove(chaser);
        if (chasers.Count == 0)
        {
            sM.SwitchMusic("OutsideMusic");
        }
    }
}
