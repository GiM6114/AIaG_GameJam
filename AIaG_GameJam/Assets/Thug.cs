using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thug : MonoBehaviour
{
    [SerializeField] GameObject defaultPhysicItem;
    [SerializeField] Item itemToGive;
    [SerializeField] Vector3 placeToPutObject;

    [System.NonSerialized] public bool given = false;

    public GameObject text1;
    public GameObject text2;

    public void OnWallPainted()
    {
        if (given)
        {
            return;
        }

        GameObject pIGO = Instantiate(defaultPhysicItem, transform.position + placeToPutObject, Quaternion.identity);
        pIGO.GetComponent<PhysicItem>().item = itemToGive;
        pIGO.name = itemToGive.name;
        given = true;

        if (text1 != null)
        {
            text1.gameObject.SetActive(false);
        }
        if (text2 != null)
        {
            text2.gameObject.SetActive(true);
            GetComponent<Animator>().SetTrigger("traded");
        }
    }
}
