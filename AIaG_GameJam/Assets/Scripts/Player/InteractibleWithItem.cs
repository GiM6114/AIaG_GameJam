using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractibleWithItem : Interactible
{
    public string itemNeededName;
    public bool itemDestructionAfterUse;

    public virtual void OnInteraction()
    {
        Interacted();
    }
}
