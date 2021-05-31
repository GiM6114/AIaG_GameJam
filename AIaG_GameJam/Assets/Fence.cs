using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Fence : MonoBehaviour
{
    [SerializeField] float speedToBreak;
    [SerializeField] GameObject fenceBroken;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name != "Bear")
        {
            return;
        }
        if(Mathf.Abs(collision.gameObject.GetComponent<AIPath>().velocity.y) > speedToBreak)
        {
            Break();
        }
    }

    private void Break()
    {
        Destroy(gameObject);
        fenceBroken.SetActive(true);
        gameObject.SetActive(false);
    }
}
