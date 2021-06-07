using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<GrassPlayer>().inGrassZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<GrassPlayer>().inGrassZone = false;
        }
    }
}
