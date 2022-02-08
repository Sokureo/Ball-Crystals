using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGood : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            player.Bounce();
        }
    }

    void Update()
    {
        if (transform.position.z < Camera.main.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
