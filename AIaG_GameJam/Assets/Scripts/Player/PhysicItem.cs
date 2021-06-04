using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicItem : MonoBehaviour
{
    [SerializeField] public Item item;
    [System.NonSerialized] public bool canBePickedUp = true;

    private void Start()
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = item.sprite;
    }

    public void PickedUp()
    {
        Destroy(gameObject);
    }
}
