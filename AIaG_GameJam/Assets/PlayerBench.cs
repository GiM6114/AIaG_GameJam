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
    [SerializeField] ParticleSystem ps;

    private Sprite sprBench1;
    [SerializeField] Sprite sprBench2;

    [System.NonSerialized] public bool isBlue;
    PlayerInput pI;
    SpriteRenderer sR;

    private bool sprBenchSet;

    private void Awake()
    {
        iWA.interacted += OnWaterIn;
        bench.GetComponent<InteractibleWithInteract>().interacted += OnInteractedWithBench;
        sR = GetComponent<SpriteRenderer>();
        sprBench1 = bench.GetComponent<SpriteRenderer>().sprite;
        sprBenchSet = true;
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
        bench.GetComponent<SpriteRenderer>().sprite = sprBench2;
        sprBenchSet = false;
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

    private void FixedUpdate()
    {
        if (isBlue)
        {
            ps.Play();
        }

        if (!isBlue && !sprBenchSet)
        {
            bench.GetComponent<SpriteRenderer>().sprite = sprBench1;
            sprBenchSet = true;
        }
    }
}
