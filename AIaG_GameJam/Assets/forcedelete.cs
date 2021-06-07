using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcedelete : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -0.25f)
        {
            Destroy(gameObject);
        }
    }
}
