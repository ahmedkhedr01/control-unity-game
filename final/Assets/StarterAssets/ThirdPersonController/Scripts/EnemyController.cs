using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Make sure to set the tag for the player GameObject
    }

    void Update()
    {
        MoveAndRotate();
    }

    void MoveAndRotate()
    {
        // Calculate the direction from the enemy to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Make the enemy rotate towards the player's position
        transform.LookAt(player);

        // Keep the enemy at its current y position (fixed in its position)
        directionToPlayer.y = 0;
    }
}
