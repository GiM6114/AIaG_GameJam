using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallToVandalize : Interactible
{
    [SerializeField] Transform thugTransform;
    [SerializeField] Thug thug;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && collision.GetComponent<PlayerBench>().isBlue)
        {
            Interacted();
            collision.GetComponent<PlayerBench>().isBlue = false;
            collision.GetComponent<SpriteRenderer>().color = Color.white;
            GetComponent<SpriteRenderer>().color = collision.GetComponent<PlayerBench>().benchColor;
            thug.OnWallPainted();
        }
    }
}
