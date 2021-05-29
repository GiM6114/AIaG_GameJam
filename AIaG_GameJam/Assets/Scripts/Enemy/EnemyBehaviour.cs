using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float distanceGiveUp;

    bool isChasing = false;
    public bool instantChase;
    List<Vector2> path;
    AIPath aiPath;
    AIDestinationSetter destinationSetter;
    GameObject player;
    [System.NonSerialized] public Vector3 defaultPosition;

    private void Awake()
    {
        if(defaultPosition == null)
        {
            defaultPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        destinationSetter = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();

        aiPath.maxSpeed = speed;
        destinationSetter.target = player.transform;
        if (instantChase)
        {
            AngerTrigger();
        }
        else
        {
            Idle();
        }
    }

    private void Update()
    {
        if (isChasing)
        {
            if(Vector2.Distance(transform.position, player.transform.position) > distanceGiveUp)
            {
                Idle();
            }
        }
    }

    public void AngerTrigger()
    {
        isChasing = true;
        aiPath.canSearch = true;
        aiPath.canMove = true;
    }

    private void Idle()
    {
        transform.localPosition = defaultPosition;
        isChasing = false;
        aiPath.canSearch = false;
        aiPath.canMove = false;
    }

    // pour le reset : quand on a OnDisable (aka on sort de subscene active) on Idle() + retourner au spawn
}
