using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBad : MonoBehaviour
{
    void Update()
    {
        if (transform.position.z < Camera.main.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
