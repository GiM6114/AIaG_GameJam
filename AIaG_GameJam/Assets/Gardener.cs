using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gardener : InteractibleWithItem
{
    [SerializeField] GameObject defaultPhysicItem;
    [SerializeField] Item shears;
    bool donne = false;

    public override void OnInteraction()
    {
        if (donne)
        {
            return;
        }
        base.OnInteraction();
        GameObject pIGO = Instantiate(defaultPhysicItem, transform.position + Vector3.down, Quaternion.identity);
        pIGO.GetComponent<PhysicItem>().item = shears;
        donne = true;
    }
}
