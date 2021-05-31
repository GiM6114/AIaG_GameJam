using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBench : MonoBehaviour
{
    [SerializeField] InteractibleWithInteract benchInteractible;
    [SerializeField] Vector3 tpPlace;

    bool isBlue;
    PlayerInput pI;

    private void Awake()
    {
        benchInteractible.interacted += OnInteractedWithBench;
    }

    private void OnInteractedWithBench()
    {
        isBlue = true;
        // changer sprite perso
        // le tp sur le banc
        transform.position = tpPlace;
        // chger le playerinput de actionmap
        pI.SwitchCurrentActionMap("Sit");
    }
}
