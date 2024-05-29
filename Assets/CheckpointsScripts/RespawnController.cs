using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public Transform respawnPoint; // Assign this in the Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Respawn the player at the respawn point
            collision.transform.position = respawnPoint.position;
            // Add any additional logic like resetting health, etc.
        }
    }
}

