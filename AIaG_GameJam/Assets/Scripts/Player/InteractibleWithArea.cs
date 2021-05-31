using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractibleWithArea : Interactible
{
    [SerializeField] string nameOfForbidden;

    [NonSerialized] public Action interacted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == nameOfForbidden)
        {
            Interacted();
            interacted?.Invoke();
            
        }
    }
}
