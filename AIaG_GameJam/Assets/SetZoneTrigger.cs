using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetZoneTrigger : MonoBehaviour
{
    [SerializeField] List<EnemyBehaviour> enemyBehaviours;
    [SerializeField] Crab crab;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach(EnemyBehaviour eB in enemyBehaviours)
            {
                eB.AngerTrigger();
            }
            crab.chasing = true;
        }
    }
}
