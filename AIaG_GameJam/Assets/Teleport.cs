using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{
    [SerializeField] Animator blackScreenAnimator;
    [SerializeField] Transform otherWay;
    [SerializeField] Vector3 direction;

    bool startTp;
    GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        player = collision.gameObject;
        PlayerInput pI = player.GetComponent<PlayerInput>();
        pI.SwitchCurrentActionMap("Stop");
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = direction * 3;
        blackScreenAnimator.SetBool("Black", true);
        StartCoroutine("Teleportation");
    }

    IEnumerator Teleportation()
    {
        yield return new WaitForSeconds(0.8f);
        otherWay.gameObject.SetActive(false);
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        player.transform.position = otherWay.localPosition;
        rb.velocity = direction * 3;
        blackScreenAnimator.SetBool("Black", false);
        yield return new WaitForSeconds(0.7f);
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        otherWay.gameObject.SetActive(true);
        PlayerInput pI = player.GetComponent<PlayerInput>();
        pI.SwitchCurrentActionMap("Gameplay");
    }
}
