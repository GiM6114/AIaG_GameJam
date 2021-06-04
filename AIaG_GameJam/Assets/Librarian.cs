using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Librarian : MonoBehaviour
{
    [SerializeField] InteractibleWithInteract iWA;
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    EnemyBehaviour eB;

    private void Awake()
    {
        eB = GetComponent<EnemyBehaviour>();
        iWA.interacted += eB.AngerTrigger;
        iWA.interacted += Angered;
    }

    private void Update()
    {
        if(!eB.isChasing)
        {
            text1.SetActive(true);
            text2.SetActive(false);
        }
    }

    private void Angered()
    {
        text1.SetActive(false);
        text2.SetActive(true);
    }
}
