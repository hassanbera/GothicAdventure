using UnityEngine;
using System.Collections;

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
                IPlayer tempPlayer = player;
                // Apply health boost decorator
                tempPlayer = new AttackBoost(player, attackBonus);
                tempPlayer.ApplyBoost();
                StartCoroutine(RemoveBoost(attackBonus));

                player = new AttackBoost(player, -attackBonus);
                player.ApplyBoost();
            }
            Destroy(gameObject); // Destroy the fruit after collision
        }
    }

    public IEnumerator RemoveBoost(int attackBonus)
    {
        yield return new WaitForSeconds(5);
    }
}
