using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPlayer : MonoBehaviour
{

    public ParticleSystem grassPS;

    public bool inGrassZone = false;

    // Update is called once per frame
    void Update()
    {
        if (inGrassZone)
        {
            grassPS.Play();
        }
    }


}
