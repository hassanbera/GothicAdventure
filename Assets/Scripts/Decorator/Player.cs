using UnityEngine;
public class Player : MonoBehaviour, IPlayer
{
    private PlayerHealth playerHealth;
    private int attackDamage = 40;
    
    public int Attack
    {
        get { return attackDamage; }
        set { attackDamage = value; }
    }

    public int Speed { get; set; }
    void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public float Health
    {
        get { return playerHealth.Health; }
        set { playerHealth.Health = value; }
    }

    public void ApplyBoost()
    {
        // Basic behavior without any boosts
    }

}
