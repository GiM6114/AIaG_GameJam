using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{
    [SerializeField] Animator blackScreenAnimator;
    [SerializeField] Transform otherWay;
    [SerializeField] Vector3 direction;
    [SerializeField] float countdown;

    float timer;
    bool startTp;
    GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        player = collision.gameObject;
        PlayerInput pI = collision.gameObject.GetComponent<PlayerInput>();
        pI.DeactivateInput();
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = direction * 3;
        StartCoroutine("Teleportation");
    }

    IEnumerator Teleportation()
    {
        yield return new WaitForSeconds(1f);
        player.transform.position = otherWay.localPosition;
        yield return new WaitForSeconds(1f);
    }
}
