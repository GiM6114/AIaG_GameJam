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
    [NonSerialized] public bool isChasing = false;
    Interactible interactible;
    Rigidbody2D rb;
    PlayerChased pC;

    private void Awake()
    {
        pC = player.GetComponent<PlayerChased>();
        rb = GetComponent<Rigidbody2D>();
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
        pC.AddChaser(gameObject);
        isChasing = true;
        aiPath.canSearch = true;
        aiPath.canMove = true;
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
    }

    public void Idle()
    {
        pC.RemoveChaser(gameObject);
        transform.position = defaultPosition;
        isChasing = false;
        aiPath.canSearch = false;
        aiPath.canMove = false;
        rb.constraints |= RigidbodyConstraints2D.FreezeAll;
    }
}
