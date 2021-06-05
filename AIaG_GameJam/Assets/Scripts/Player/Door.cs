using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : InteractibleWithInteract
{

    public bool Push = false;
    private void Awake()
    {
        interacted += OnDone;
    }

    public override void OnInteraction()
    {
        base.OnInteraction();
        if (Push)
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerMovement>().pushed = true;
            player.GetComponent<PlayerInput>().SwitchCurrentActionMap("Stop");
            print(GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10f);
            print(GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity);
        }
    }

    private void OnDone()
    {
        Destroy(gameObject);
    }
}
