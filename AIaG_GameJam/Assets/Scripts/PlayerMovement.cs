using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rb;
    Animator animator;

    Vector2 movement;

    [System.NonSerialized] public bool beingTped = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
        
    public void Move(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>();

        if (ctx.canceled)
        {
            movement = Vector3.zero;
            return;
        }

        if (!ctx.performed)
        {
            return;
        }
        if (movement.x >= 0.05f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (movement.x <= -0.05f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void Update()
    {
        if (!beingTped)
        {
            rb.velocity = movement * speed;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("player_kick"))
        {
            return;
        }

        if (Mathf.Abs(rb.velocity.magnitude) >= 0.05f)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("player_walk"))
            {
                animator.Play("player_walk");
            }
        } else
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("player_idle"))
            {
                animator.Play("player_idle");
            }
        }
    }

    public void KickRequest()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("player_kick"))
        {
            animator.Play("player_kick");
        }
    }
}
