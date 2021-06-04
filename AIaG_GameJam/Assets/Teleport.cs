using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator blackScreenAnimator;
    [SerializeField] Transform otherWay;
    [SerializeField] Vector3 direction;

    bool startTp;

    PlayerInput pI;
    Rigidbody2D rb;
    PlayerMovement pM;

    SoundManager sM;
    bool isIn;

    private void Awake()
    {
        sM = GameObject.Find("Canvas").GetComponent<SoundManager>();
        isIn = name == "In";

        pI = player.GetComponent<PlayerInput>();
        rb = player.GetComponent<Rigidbody2D>();
        pM = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        pI.SwitchCurrentActionMap("Stop");
        pM.beingTped = true;
        rb.velocity = direction * 3;
        blackScreenAnimator.SetBool("Black", true);
        StartCoroutine("Teleportation");
    }

    IEnumerator Teleportation()
    {
        yield return new WaitForSeconds(0.8f);
        otherWay.gameObject.SetActive(false);
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        player.transform.position = otherWay.position;
        rb.velocity = direction * 3;
        blackScreenAnimator.SetBool("Black", false);

        sM.SwitchMusic(isIn ? "OutsideMusic" : "InDoorMusic");

        yield return new WaitForSeconds(0.7f);
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        otherWay.gameObject.SetActive(true);
        PlayerInput pI = player.GetComponent<PlayerInput>();
        pI.SwitchCurrentActionMap("Gameplay");
        pM.beingTped = false;
    }
}
