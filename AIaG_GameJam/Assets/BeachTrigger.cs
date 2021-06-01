using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachTrigger : Interactible
{
    [SerializeField] ManBeachAI mB;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "PlasticBottle")
        {
            Interacted();
            mB.OnPlasticBottleDropped(collision.transform);
        }
    }
}
