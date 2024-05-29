using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour
{
    public int attackBonus = 12; // Amount of attack bonus to add

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
                StartCoroutine(RemoveBoost(boostedPlayer, attackBonus));
            }
            Destroy(gameObject); // Destroy the fruit after collision
        }
    }

    private IEnumerator RemoveBoost(IPlayer player, int attackBonus)
    {
        yield return new WaitForSeconds(5);

        // Apply negative attack boost to remove the previous bonus
        IPlayer boostedPlayer = new AttackBoost(player, -attackBonus);
        boostedPlayer.ApplyBoost();
    }
}
