using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject defaultPhysicItem;
    Item item = null;
    Queue<GameObject> itemsNearby = new Queue<GameObject>();
    Action useFunction = null;

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
        {
            return;
        }

        // récup objet proche si il y en a un
        if(itemsNearby.Count > 0)
        {
            Drop();

            PhysicItem physicItem = itemsNearby.Dequeue().GetComponent<PhysicItem>();
            item = physicItem.item;
            physicItem.PickedUp();
            return;
        }

        // cas ou pas d'obj proche
        if(item != null)
        {
            item.Use();
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
        if(item == null)
        {
            return;
        }
        Instantiate(defaultPhysicItem, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            itemsNearby.Enqueue(collision.gameObject);
        }
    }
}
