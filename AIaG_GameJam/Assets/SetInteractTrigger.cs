using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInteractTrigger : MonoBehaviour
{
    [SerializeField] List<EnemyBehaviour> enemyBehaviours;

    InteractibleWithInteract iWA;

    private void Awake()
    {
        iWA = GetComponent<InteractibleWithInteract>();
        foreach(var eB in enemyBehaviours)
        {
            iWA.interacted += eB.AngerTrigger;
        }
    }
}
