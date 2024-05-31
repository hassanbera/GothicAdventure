using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avocado : MonoBehaviour
{
    public int speedBoost = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IPlayer player = other.GetComponent<IPlayer>();
            if (player != null)
            {
                Debug.Log("Player collided with avocado");
                // Apply speed boost decorator
                IPlayer boostedPlayer = new SpeedBoost(player, speedBoost);
                boostedPlayer.ApplyBoost();
            }
            Destroy(gameObject); // Destroy the avocado after collision
        }
    }
}
