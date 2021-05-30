using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] PlayerObject pO;
    EnemyBehaviour eB;
    bool playerHasBone;
    int etat = 0; // 0 rien, 1 suit joueur, 2 va sur l'os

    private void Awake()
    {
        eB = GetComponent<EnemyBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        if (playerHasBone)
        {
            etat = 1;
            eB.AngerTrigger();
            eB.destinationSetter.target = eB.player.transform;
        }
    }

    private void Update()
    {
        playerHasBone = pO.item.name == "Bone";
        if((etat == 1 || etat == 0) && !playerHasBone)
        {
            // le joueur vient de lacher l'os
            etat = 2;
            GameObject bone = GameObject.Find("Bone");
            if(bone != null)
            {
                eB.destinationSetter.target = bone.transform;
                etat = 2;
            }
            else
            {
                etat = 0;
            }
        }
    }
}
