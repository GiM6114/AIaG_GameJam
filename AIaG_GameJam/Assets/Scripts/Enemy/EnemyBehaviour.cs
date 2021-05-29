using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform defaultPosition;
    [SerializeField] float speed;

    bool isChasing = false;
    List<Vector2> path;
    AIPath aiPath;
    AIDestinationSetter destinationSetter;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        destinationSetter = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();

        aiPath.maxSpeed = speed;
        destinationSetter.target = player.transform;
        Idle();
    }

    private void AngerTrigger()
    {
        isChasing = true;
        aiPath.canSearch = true;
        aiPath.canMove = true;
    }

    private void Idle()
    {
        isChasing = false;
        aiPath.canSearch = false;
        aiPath.canMove = false;
    }

    // pour le reset : quand on a OnDisable (aka on sort de subscene active) on Idle() + retourner au spawn
}
