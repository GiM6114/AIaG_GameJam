using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerObject : MonoBehaviour
{
    [SerializeField] GameObject defaultPhysicItem;
    [SerializeField] SpriteRenderer sR;

    public Item item = null;
    List<PhysicItem> itemsNearby = new List<PhysicItem>();
    List<InteractibleWithInteract> interactiblesNearby = new List<InteractibleWithInteract>();

    public event Action<Transform> DropBone;
    public event Action PickupBone;

    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
        {
            return;
        }

        // r�cup objet proche si il y en a un
        if (itemsNearby.Count > 0)
        {
            Drop();

            PhysicItem physicItem = itemsNearby[0].GetComponent<PhysicItem>();
            item = physicItem.item;
            physicItem.PickedUp();
            sR.sprite = item.sprite;

            if(item.name == "Bone")
            {
                PickupBone?.Invoke();
            }

            return;
        }

        // cas ou pas d'obj proche
        foreach(InteractibleWithInteract interactible in interactiblesNearby)
        {
            if (interactible.needItem)
            {
                if(item.name != interactible.itemNeededName)
                {
                    break;
                }
            }
            else
            {
                playerMovement.KickRequest();
            }
            // on est sorti si besoin d'item et pas le bon item


            interactible.OnInteraction();
            if (interactible.itemDestructionAfterUse)
            {
                item = null;
                sR.sprite = null;
            }
            return;
        }

        // COUP DE PIED
        playerMovement.KickRequest();
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

        GameObject itemDropped = Instantiate(defaultPhysicItem, transform.position+0.05f*Vector3.forward, Quaternion.identity);
        PhysicItem itemDroppedPI = itemDropped.GetComponent<PhysicItem>();
        itemDroppedPI.item = item;
        itemDropped.name = item.name;

        if (item.name == "Bone")
        {
            DropBone?.Invoke(itemDropped.transform);
        }

        item = null;
        sR.sprite = null;
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
            interactiblesNearby.Add(collision.gameObject.GetComponent<InteractibleWithInteract>());
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
            interactiblesNearby.Remove(collision.gameObject.GetComponent<InteractibleWithInteract>());
            return;
        }
    }
}

