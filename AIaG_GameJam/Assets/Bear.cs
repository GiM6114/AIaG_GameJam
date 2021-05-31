using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;

public class Bear : MonoBehaviour
{
    [SerializeField] float distanceGiveUp;
    [SerializeField] GameObject player;

    [NonSerialized] public Vector3 defaultPosition;
    [NonSerialized] public AIDestinationSetter destinationSetter;

    AIPath aiPath;
    bool isChasing = false;
    Interactible interactible;

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        interactible = GetComponent<Interactible>();

        interactible.interacted += AngerTrigger;

        defaultPosition = transform.position;
        Idle();
    }

    private void Update()
    {
        if(isChasing && Vector2.Distance(transform.position, player.transform.position) > distanceGiveUp)
        {
            Idle();
        }   
    }

    private void AngerTrigger()
    {
        isChasing = true;
        aiPath.canSearch = true;
        aiPath.canMove = true;
    }

    private void Idle()
    {
        transform.position = defaultPosition;
        isChasing = false;
        aiPath.canSearch = false;
        aiPath.canMove = false;
    }
}
