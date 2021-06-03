using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractibleWithInteract : Interactible
{
    [SerializeField] GameObject spawnEnraged;

    public bool needItem = false;
    public string itemNeededName;
    public bool itemDestructionAfterUse;
    public int numberOfTimesNeeded = 1;
    int numberOfTimes = 0;


    public virtual void OnInteraction()
    {
        numberOfTimes++;
        if(numberOfTimesNeeded == numberOfTimes)
        {
            numberOfTimes = 0;
            Interacted();
            if (spawnEnraged == null)
            {
                return;
            }
            Instantiate(spawnEnraged, transform.position + new Vector3(0,0,-0.2f), Quaternion.identity);
            EnemyBehaviour eB = spawnEnraged.GetComponent<EnemyBehaviour>();
            eB.killWhenDone = true;
        }
    }
}
