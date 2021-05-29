using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetZoneTrigger : MonoBehaviour
{
    [SerializeField] List<EnemyBehaviour> enemyBehaviours;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach(EnemyBehaviour eB in enemyBehaviours)
            {
                eB.AngerTrigger();
            }
        }
    }
}
