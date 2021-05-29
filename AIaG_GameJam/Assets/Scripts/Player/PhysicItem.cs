using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicItem : MonoBehaviour
{
    [SerializeField] public Item item;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.sprite;
    }

    public void PickedUp()
    {
        Destroy(gameObject);
    }
}
