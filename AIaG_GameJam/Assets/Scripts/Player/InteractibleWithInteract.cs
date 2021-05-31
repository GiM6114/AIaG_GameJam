using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleWithInteract : Interactible
{
    public bool needItem = false;
    public string itemNeededName;
    public bool itemDestructionAfterUse;

    public virtual void OnInteraction()
    {
        Interacted();
    }
}