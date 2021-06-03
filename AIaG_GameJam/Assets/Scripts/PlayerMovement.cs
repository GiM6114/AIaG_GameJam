using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Tilemap water;

    Rigidbody2D rb;
    [System.NonSerialized] public Animator animator;

    public ParticleSystem dust;

    Vector2 movement;

    [System.NonSerialized] public bool beingTped = false;

    float countdown = 0;
    [SerializeField] float repeatSoundWalking;
    SoundManager sM;

    private void Awake()
    {
        sM = GetComponent<SoundManager>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        countdown = repeatSoundWalking;
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
            if (transform.localScale.x != 1f)
            {
                dust.Play();
                transform.localScale = new Vector3(1f, 1f, 1f);
            }       
        }
        else if (movement.x <= -0.05f)
        {
            if (transform.localScale.x != -1f)
            {
                dust.Play();
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }


    TileBase previousTile;

    private void Update()
    {
        TileBase t = water.GetTile(water.WorldToCell(transform.position));
        if((previousTile == null && t != null) || (previousTile != null && t == null))
        {
            sM.PlaySound("Swimming");
        }
        previousTile = t;

        if (t == null && countdown < 0)
        {
            sM.PlaySound("Walking");
            countdown = repeatSoundWalking;
        }

        if(Mathf.Abs(rb.velocity.x) > 0 || Mathf.Abs(rb.velocity.y) > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            countdown = repeatSoundWalking;
        }

        if (!beingTped)
        {
            rb.velocity = movement * speed;
        }

        if (t != null)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("player_swim"))
            {
                animator.Play("player_swim");
            }
            return;
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
                dust.Play();
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
            sM.PlaySound("Kick");
        }
    }
}
