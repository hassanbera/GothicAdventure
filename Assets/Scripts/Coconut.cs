using UnityEngine;
using System.Collections;

public class Coconut : MonoBehaviour
{
    public int attackBonus = 2; // Amount of attack bonus to add

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IPlayer player = other.GetComponent<IPlayer>();
            if (player != null)
            {
                // Apply attack boost decorator
                IPlayer boostedPlayer = new AttackBoost(player, attackBonus);
                boostedPlayer.ApplyBoost();
            }
            Destroy(gameObject); // Destroy the fruit after collision
        }
    }

}
