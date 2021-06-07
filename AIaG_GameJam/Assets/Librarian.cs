using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Librarian : MonoBehaviour
{
    [SerializeField] InteractibleWithInteract iWA;
    [SerializeField] InteractibleWithInteract iWA2;
    [SerializeField] GameObject text1;
    //[SerializeField] GameObject text2;
    EnemyBehaviour eB;

    private void Awake()
    {
        eB = GetComponent<EnemyBehaviour>();
        iWA.interacted += eB.AngerTrigger;
        iWA.interacted += Angered;
        iWA2.interacted += eB.AngerTrigger;
        iWA2.interacted += Angered;
        iWA2.interacted += BellSound;
    }

    private void Update()
    {
        if(eB.isChasing)
        {
            text1.SetActive(false);
            //text2.SetActive(false);
        } else
        {
            text1.SetActive(true);
        }
    }

    private void Angered()
    {
        Debug.Log("ANGER");
        text1.SetActive(false);
        //text2.SetActive(true);
    }

    private void BellSound()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SoundManager>().PlaySound("Bell");
    }
}
