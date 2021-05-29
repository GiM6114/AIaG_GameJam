using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractibleWithItem
{
    public override void OnInteraction()
    {
        base.OnInteraction();
        Destroy(gameObject);
    }
}
