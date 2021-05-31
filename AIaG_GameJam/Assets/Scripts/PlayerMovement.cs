using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
        
    public void Move(InputAction.CallbackContext ctx)
    {

        Vector2 movement = ctx.ReadValue<Vector2>();
        rb.velocity = movement*speed;
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
}
