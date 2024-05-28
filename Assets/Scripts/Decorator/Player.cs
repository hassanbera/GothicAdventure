using UnityEngine;
public class Player : MonoBehaviour, IPlayer
{
    private PlayerHealth playerHealth;
    private int attackDamage = 40;
    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public int Health
    {
        get { return playerHealth.Health; }
        set { playerHealth.Health = value; }
    }

    public void ApplyBoost()
    {
        // Basic behavior without any boosts
    }
}
