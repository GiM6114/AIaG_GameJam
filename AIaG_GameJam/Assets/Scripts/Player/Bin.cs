using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : InteractibleWithoutItem
{
    [SerializeField] GameObject racoon;
    [SerializeField] GameObject defaultPhysicItem;
    [SerializeField] float racoonCountdown;
    [SerializeField] Item key;

    bool opened = false;
    bool racoonSpawned = false;

    public override void OnInteraction()
    {
        if (opened)
        {
            return;
        }
        base.OnInteraction();
        GameObject pIGO = Instantiate(defaultPhysicItem, transform.position + Vector3.down, Quaternion.identity);
        pIGO.GetComponent<PhysicItem>().item = key;
        opened = true;
    }

    private void Update()
    {
        if (racoonSpawned)
        {
            return;
        }
        if(racoonCountdown > 0 && opened)
        {
            racoonCountdown -= Time.deltaTime;
        }
        else if (racoonCountdown < 0)
        {
            Instantiate(racoon, transform.position + Vector3.left, Quaternion.identity);
            EnemyBehaviour eB = racoon.GetComponent<EnemyBehaviour>();
            eB.defaultPosition = new Vector3(0,0,10);
            racoonSpawned = true;
        }
    }
}
