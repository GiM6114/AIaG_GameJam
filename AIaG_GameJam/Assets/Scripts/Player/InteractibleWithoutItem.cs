using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleWithoutItem : Interactible
{
    public virtual void OnInteraction()
    {
        Interacted();
    }
}
