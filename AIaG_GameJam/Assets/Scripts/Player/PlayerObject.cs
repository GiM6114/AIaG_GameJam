using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Tilemaps;

public class PlayerObject : MonoBehaviour
{
    [SerializeField] Tilemap water;
    [SerializeField] GameObject defaultPhysicItem;
    [SerializeField] SpriteRenderer sR;
    [SerializeField] Animator anim;

    public Item item = null;
    List<PhysicItem> itemsNearby = new List<PhysicItem>();
    List<InteractibleWithInteract> interactiblesNearby = new List<InteractibleWithInteract>();

    public event Action<Transform, string> DropEvent;
    public event Action PickupBone;

    PlayerMovement playerMovement;
    SoundManager sM;

    private void Awake()
    {
        sM = GetComponent<SoundManager>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || water.GetTile(water.WorldToCell(transform.position)) != null)
        {
            return;
        }

        if (playerMovement.animator.GetCurrentAnimatorStateInfo(0).IsName("player_kick")) return;

        // récup objet proche si il y en a un

        if (itemsNearby.Count > 0)
        {
            foreach (var i in itemsNearby)
            {
                Drop();
                PhysicItem physicItem = itemsNearby[0].GetComponent<PhysicItem>();
                if (!physicItem.canBePickedUp)
                {
                    continue;
                }
                item = physicItem.item;
                physicItem.PickedUp();
                sR.sprite = item.sprite;
                anim.Play("pick", -1, 0f);

                if (item.name == "Bone")
                {
                    PickupBone?.Invoke();
                }

                sM.PlaySound("Pickup");

                return;
            }

        }

        // cas ou pas d'obj proche
        foreach(InteractibleWithInteract interactible in interactiblesNearby)
        {
            if (interactible.needItem)
            {
                if(item == null || item.name != interactible.itemNeededName)
                {
                    break;
                }
            }
            else
            {
                playerMovement.KickRequest();
            }
            // on est sorti si besoin d'item et pas le bon item

            if(interactible.needItem) playerMovement.InteractionRequest(item.name);
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
        if (item == null || water.GetTile(water.WorldToCell(transform.position)) != null)
        {
            return;
        }

        GameObject itemDropped = Instantiate(defaultPhysicItem, transform.position+0.05f*Vector3.forward+0.4f*Vector3.right*Mathf.Sign(transform.localScale.x), Quaternion.identity);
        PhysicItem itemDroppedPI = itemDropped.GetComponent<PhysicItem>();
        itemDroppedPI.item = item;
        itemDropped.name = item.name;

        DropEvent?.Invoke(itemDropped.transform, item.name);

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

