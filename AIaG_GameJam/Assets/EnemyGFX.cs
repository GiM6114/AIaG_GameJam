using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        /*
        if(Mathf.Abs(aiPath.desiredVelocity.x) > Mathf.Abs(aiPath.desiredVelocity.y))
        {
            if(aiPath.desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else
        {
            if (aiPath.desiredVelocity.y >= 0.01f)
            {
                transform.localScale = new Vector3(1f, -1f, 1f);
            }
            else if (aiPath.desiredVelocity.y <= -0.01f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        */
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (Mathf.Abs(aiPath.velocity.magnitude) >= 0.05f)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("chase"))
            {
                anim.Play("chase");
            }
        }
        else
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                anim.Play("idle");
            }
        }

    }
}
