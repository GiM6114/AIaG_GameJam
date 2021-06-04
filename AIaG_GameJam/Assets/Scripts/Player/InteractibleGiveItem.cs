using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleGiveItem : InteractibleWithInteract
{
    [SerializeField] GameObject defaultPhysicItem;
    [SerializeField] Item itemToGive;
    [SerializeField] Vector3 placeToPutObject;
    [SerializeField] float delay = 0;

    [System.NonSerialized] public bool given = false;

    public GameObject text1;
    public GameObject text2;

    public override void OnInteraction()
    {
        if (given)
        {
            return;
        }
        base.OnInteraction();
        StartCoroutine("Delay");
        given = true;
        if (text1 != null) {
            text1.gameObject.SetActive(false);
        }
        if (text2 != null)
        {
            text2.gameObject.SetActive(true);
            GetComponent<Animator>().SetTrigger("traded");
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        GameObject pIGO = Instantiate(defaultPhysicItem, transform.position + placeToPutObject, Quaternion.identity);
        pIGO.GetComponent<PhysicItem>().item = itemToGive;
        pIGO.name = itemToGive.name;
    }
}
