using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleWithArea : Interactible
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Interacted();
            if (!WorldEngine.i.HasRuleBeenBroke(lawIndex))
            {
                WorldEngine.i.BreakRuleSign(lawIndex);
            }
            
        }
    }
}
