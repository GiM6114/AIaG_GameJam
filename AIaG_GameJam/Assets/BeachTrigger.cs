using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachTrigger : Interactible
{
    [SerializeField] ManBeachAI mB;
    [SerializeField] PlayerObject pO;

    bool playerOnBeach = false;

    private void Awake()
    {
        pO.DropEvent += OnBottleDropped;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            playerOnBeach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerOnBeach = false;
        }
    }

    private void OnBottleDropped(Transform bottle, string itemName)
    {
        if (itemName != "PlasticBottle" || !playerOnBeach)
        {
            return;
        }
        Interacted();
        mB.OnPlasticBottleDropped(bottle);
    }
}
