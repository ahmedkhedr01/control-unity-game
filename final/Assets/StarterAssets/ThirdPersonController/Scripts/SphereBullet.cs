using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthControl healthControl = collision.gameObject.GetComponent<HealthControl>();
            healthControl.DecreaseHealth(15);
        }
    }

}
