using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.InputSystem;

public class Dog : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] InteractibleWithArea garden;
    [SerializeField] GameObject bushWithStick;
    [SerializeField] GameObject defaultPhysicItem;
    [SerializeField] Item stick;
    [SerializeField] Animator camAnim;

    int state = 1; // 1 rien, 2 suit joueur, 3 va sur l'os, 4 cherche b�ton
    PlayerObject pO;
    AIPath aiPath;
    AIDestinationSetter destinationSetter;
    PlayerInput pI;
    bool hasDiscoveredStick = false;

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        pO = player.GetComponent<PlayerObject>();
        pI = player.GetComponent<PlayerInput>();

        pO.DropBone += OnBoneDropped;
        pO.PickupBone += OnBonePickedUp;
        garden.interacted += OnGardenEnter;

        EnablePathfinding(false, 0);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || pO.item == null)
        {
            return;
        }

        if(state == 1 && pO.item.name == "Bone")
        {
            // switch state from 1 to 2
            EnablePathfinding(true, 1.75f, player.transform);
            state = 2;
        }
    }*/

    private void Update()
    {
        Debug.Log(aiPath.reachedEndOfPath);
        Debug.Log(aiPath.reachedDestination);
        if(state == 1 && pO.item != null && pO.item.name == "Bone" && Vector2.Distance(player.transform.position, transform.position) < 2)
        {
            EnablePathfinding(true, 1.75f, player.transform);
            state = 2;
        }
        else if(state == 4 && destinationSetter.target != player.transform && aiPath.reachedDestination)
        {
            EnablePathfinding(true, 1.75f, player.transform);
            state = 5;
        }
        else if(state == 5 && destinationSetter.target == player.transform && aiPath.reachedDestination)
        {
            Vector3 direction = player.transform.position - transform.position;
            GameObject pIGO = Instantiate(defaultPhysicItem, transform.position + direction.normalized, Quaternion.identity);
            pIGO.GetComponent<PhysicItem>().item = stick;
            pIGO.name = stick.name;
            pI.SwitchCurrentActionMap("Gameplay");
            state = 2;
            camAnim.SetBool("cinematique", false);
        }
    }

    private void OnGardenEnter()
    {
        if (hasDiscoveredStick)
        {
            return;
        }
        hasDiscoveredStick = true;
        state = 4;
        EnablePathfinding(true, 1, bushWithStick.transform);
        pI.SwitchCurrentActionMap("Stop");
        camAnim.SetBool("cinematique", true);
    }

    private void OnBoneDropped(Transform boneTransform)
    {
        if(state == 2)
        {
            EnablePathfinding(true, 0, boneTransform);
            state = 3;
        }
        if(state == 6)
        {
            EnablePathfinding(true, 0, boneTransform);
            state = 7;
        }
    }

    private void OnBonePickedUp()
    {
        if(state == 3)
        {
            EnablePathfinding(true, 1.75f, player.transform);
        }
    }

    private void EnablePathfinding(bool state, float distance, Transform target = null)
    {
        aiPath.canSearch = state;
        aiPath.canMove = state;
        aiPath.endReachedDistance = distance;
        if (state)
        {
            destinationSetter.target = target;
        }
    }
}
