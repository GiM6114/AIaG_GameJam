using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingZone : InteractibleWithItem
{
    [SerializeField] GameObject defaultPhysicItem;
    [SerializeField] Item boot;

    bool fished = false;

    public override void OnInteraction()
    {
        if (fished)
        {
            return;
        }
        base.OnInteraction();
        GameObject pIGO = Instantiate(defaultPhysicItem, transform.position + Vector3.left, Quaternion.identity);
        pIGO.GetComponent<PhysicItem>().item = boot;
        fished = true;
    }
}
