using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.InputSystem;

public class ManBeachAI : MonoBehaviour
{
    [SerializeField] PlayerInput pI;
    [SerializeField] Animator camAnim;
    [SerializeField] GameObject defaultPhysicItem;
    [SerializeField] Item banana;

    AIPath aiPath;
    AIDestinationSetter destinationSetter;
    int state = 0;
    Transform bottle;

    public void OnPlasticBottleDropped(Transform bottle)
    {
        pI.SwitchCurrentActionMap("Sit");
        camAnim.SetBool("cinematique", true);
        destinationSetter.target = bottle;
        this.bottle = bottle;
        aiPath.canSearch = true;
        aiPath.canMove = true;
        state = 1;
    }

    private void Update()
    {
        if(state == 1 && aiPath.reachedDestination)
        {
            Destroy(bottle);
            GameObject ban = Instantiate(defaultPhysicItem, transform.position, Quaternion.identity);
            ban.GetComponent<PhysicItem>().item = banana;
            ban.name = "Banana";

            pI.SwitchCurrentActionMap("Gameplay");
            camAnim.SetBool("cinematique", false);
            aiPath.canSearch = false;
            aiPath.canMove = false;
            state = 2;
        }
    }
}
