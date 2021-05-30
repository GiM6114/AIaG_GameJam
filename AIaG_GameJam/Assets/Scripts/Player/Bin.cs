using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : InteractibleGiveItem
{
    [SerializeField] GameObject racoon;
    [SerializeField] float racoonCountdown;

    bool racoonSpawned = false;

    private void Update()
    {
        if (racoonSpawned)
        {
            return;
        }
        if(racoonCountdown > 0 && given)
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
