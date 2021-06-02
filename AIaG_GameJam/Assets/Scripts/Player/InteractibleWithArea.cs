using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractibleWithArea : Interactible
{
    [SerializeField] string nameOfForbidden;

    [SerializeField] bool needitem = false;
    [SerializeField] string itemName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == nameOfForbidden)
        {
            if (needitem)
            {
                Item item = GameObject.Find("Player").GetComponent<PlayerObject>().item;
                if(item == null || item.name != itemName)
                {
                    return;
                }
            }
            Interacted();
        }
    }
}
