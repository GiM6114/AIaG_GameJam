using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractibleWithInteract
{
    private void Awake()
    {
        interacted += OnDone;
    }

    public override void OnInteraction()
    {
        base.OnInteraction();
    }

    private void OnDone()
    {
        Destroy(gameObject);
    }
}
