using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int healthBonus = 50; // Amount of health to add

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IPlayer player = other.GetComponent<IPlayer>();
            if (player != null)
            {
                // Apply health boost decorator
                player = new HealthBoost(player, healthBonus);
                player.ApplyBoost();
            }
            Destroy(gameObject); // Destroy the fruit after collision
        }
    }
}
