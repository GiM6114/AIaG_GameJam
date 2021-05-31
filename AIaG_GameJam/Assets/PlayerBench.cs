using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBench : MonoBehaviour
{
    [SerializeField] GameObject bench;
    [SerializeField] Transform tpPlace;

    bool isBlue;
    PlayerInput pI;

    private void Awake()
    {
        bench.GetComponent<InteractibleWithInteract>().interacted += OnInteractedWithBench;
    }

    private void OnInteractedWithBench()
    {
        isBlue = true;
        bench.GetComponentInChildren<BoxCollider2D>().enabled = false;
        // changer sprite perso
        transform.localScale = new Vector3(-1,1,1);
        // le tp sur le banc
        transform.position = tpPlace.position;
    }

    public void GetUp()
    {
        bench.GetComponentInChildren<BoxCollider2D>().enabled = true;
    }
}
