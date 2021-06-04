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

    [SerializeField] GameObject text1;
    //[SerializeField] GameObject text2;
    [SerializeField] GameObject text3;

    AIPath aiPath;
    AIDestinationSetter destinationSetter;
    int state = 0;
    Transform bottle;

    private void Awake()
    {
        aiPath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
    }

    public void OnPlasticBottleDropped(Transform bottle)
    {
        StartCoroutine(Delay(bottle));
    }

    IEnumerator Delay(Transform bottle)
    {
        yield return new WaitForSeconds(3f);
        pI.SwitchCurrentActionMap("Stop");
        camAnim.SetBool("cinematique", true);
        destinationSetter.target = bottle;
        this.bottle = bottle;
        aiPath.canSearch = true;
        aiPath.canMove = true;
        state = 1;
        //// TEXT ////
        text1.SetActive(false);
        //text2.SetActive(true);
    }

    private void Update()
    {
        if(state == 1 && aiPath.reachedDestination)
        {
            Destroy(bottle.gameObject);
            GameObject ban = Instantiate(defaultPhysicItem, transform.position + Vector3.right, Quaternion.identity);
            ban.GetComponent<PhysicItem>().item = banana;
            ban.name = "Banana";

            pI.SwitchCurrentActionMap("Gameplay");
            camAnim.SetBool("cinematique", false);
            aiPath.canSearch = false;
            aiPath.canMove = false;
            state = 2;
            //text2.SetActive(false);
            text3.SetActive(true);
        }
    }
}
