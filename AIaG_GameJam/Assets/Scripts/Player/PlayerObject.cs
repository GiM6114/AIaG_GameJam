using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerObject : MonoBehaviour
{
    [SerializeField] GameObject defaultPhysicItem;
    Item item = null;
    List<PhysicItem> itemsNearby = new List<PhysicItem>();
    List<Interactible> interactiblesNearby = new List<Interactible>();

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
        {
            return;
        }

        // récup objet proche si il y en a un
        if (itemsNearby.Count > 0)
        {
            Drop();

            PhysicItem physicItem = itemsNearby[0].GetComponent<PhysicItem>();
            item = physicItem.item;
            physicItem.PickedUp();
            return;
        }

        // cas ou pas d'obj proche
        if (item == null)
        {
            return;
        }

        foreach (Interactible interactible in interactiblesNearby)
        {
            if(interactible is InteractibleWithItem)
            {
                InteractibleWithItem interactibleWithItem = interactible as InteractibleWithItem;
                if (interactibleWithItem.itemNeededName == item.name)
                {
                    interactibleWithItem.OnInteraction();
                    if (interactibleWithItem.itemDestructionAfterUse)
                    {
                        item = null;
                    }
                    break;
                }
            }
        }
    }

    public void OnDrop(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || item == null)
        {
            return;
        }

        Drop();
    }

    public void Drop()
    {
        if (item == null)
        {
            return;
        }
        GameObject itemDropped = Instantiate(defaultPhysicItem, transform.position, Quaternion.identity);
        PhysicItem itemDroppedPI = itemDropped.GetComponent<PhysicItem>();
        itemDroppedPI.item = item;
        item = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            itemsNearby.Add(collision.gameObject.GetComponent<PhysicItem>());
            return;
        }
        if (collision.CompareTag("Interactible"))
        {
            interactiblesNearby.Add(collision.gameObject.GetComponent<Interactible>());
            return;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            itemsNearby.Remove(collision.gameObject.GetComponent<PhysicItem>());
            return;
        }
        if (collision.CompareTag("Interactible"))
        {
            interactiblesNearby.Remove(collision.gameObject.GetComponent<Interactible>());
            return;
        }
    }
}

