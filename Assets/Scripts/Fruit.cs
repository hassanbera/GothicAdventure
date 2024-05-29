using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int attackBonus = 12; // Amount of health to add

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IPlayer player = other.GetComponent<IPlayer>();
            if (player != null)
            {
                // Apply health boost decorator
                player = new AttackBoost(player, attackBonus);
                player.ApplyBoost();
            }
            Destroy(gameObject); // Destroy the fruit after collision
        }
    }
}
