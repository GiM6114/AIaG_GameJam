using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBench : MonoBehaviour
{
    [SerializeField] GameObject bench;
    [SerializeField] Transform tpPlace;
    public Color benchColor;
    [SerializeField] InteractibleWithArea iWA;

    [System.NonSerialized] public bool isBlue;
    PlayerInput pI;
    SpriteRenderer sR;

    private void Awake()
    {
        iWA.interacted += OnWaterIn;
        bench.GetComponent<InteractibleWithInteract>().interacted += OnInteractedWithBench;
        sR = GetComponent<SpriteRenderer>();
    }

    private void OnInteractedWithBench()
    {
        isBlue = true;
        bench.GetComponentInChildren<BoxCollider2D>().enabled = false;
        // changer sprite perso
        transform.localScale = new Vector3(-1,1,1);
        sR.color = benchColor;
        // le tp sur le banc
        transform.position = tpPlace.position;
    }

    public void GetUp()
    {
        bench.GetComponentInChildren<BoxCollider2D>().enabled = true;
    }

    private void OnWaterIn()
    {
        sR.color = Color.white;
        isBlue = false;
    }
}
