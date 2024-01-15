using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with player");
        }
    }
}
