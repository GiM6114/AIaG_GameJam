using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Crab : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Tilemap ground;
    EnemyBehaviour eB;
    GameObject player;
    [System.NonSerialized] public bool chasing = false;
    bool astar = false;
    [SerializeField] SpriteRenderer sR;

    private void Awake()
    {
        eB = GetComponent<EnemyBehaviour>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(ground.GetTile(ground.WorldToCell(transform.position)) != null)
        {
            sR.enabled = true;
        }
        else
        {
            sR.enabled = false;
        }
        if(astar == true || chasing == false)
        {
            return;
        }
        Vector2 direction = player.transform.position - transform.position;
        direction = direction.normalized;
        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;

        if(ground.GetTile(ground.WorldToCell(transform.position)) != null)
        {
            astar = true;
            eB.AngerTrigger();
        }
    }
}
