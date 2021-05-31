using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Dog : MonoBehaviour
{
    [SerializeField] GameObject player;

    int etat = 1; // 1 rien, 2 suit joueur, 3 va sur l'os, 4 cherche bâton
    PlayerObject pO;
    AIPath aiPath;
    AIDestinationSetter destinationSetter;

    private void Awake()
    {
        pO = player.GetComponent<PlayerObject>();
        pO.DropBone += OnBoneDropped;

        aiPath.canMove = false;
        aiPath.canSearch = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        if(etat == 1)
        {
            // switch state from 1 to 2

        }
    }

    private void Update()
    {
        
    }

    private void OnBoneDropped()
    {

    }
}
