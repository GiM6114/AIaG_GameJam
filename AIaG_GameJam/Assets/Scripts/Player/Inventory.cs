using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    Item item = null;

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
        {
            return;
        }

        // récup objet proche si il y en a un
            // drop objet actuel si il y en a un
            // ramasser l'autre

        item.Use();
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
        Instantiate();
    }
}
