using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleGiveItem : InteractibleWithInteract
{
    [SerializeField] GameObject defaultPhysicItem;
    [SerializeField] Item itemToGive;
    [SerializeField] Vector3 placeToPutObject;

    [System.NonSerialized] public bool given = false;

    public override void OnInteraction()
    {
        if (given)
        {
            return;
        }
        base.OnInteraction();
        GameObject pIGO = Instantiate(defaultPhysicItem, transform.position + placeToPutObject, Quaternion.identity);
        pIGO.GetComponent<PhysicItem>().item = itemToGive;
        given = true;
    }
}
