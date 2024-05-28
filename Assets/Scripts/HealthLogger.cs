using UnityEngine;

public class HealthLogger : MonoBehaviour, IHealthObserver
{
    public void OnHealthChanged(int health)
    {
        Debug.Log("Player health changed to: " + health);
    }

    private void Start()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        playerHealth.RegisterObserver(this);
    }

    private void OnDestroy()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.RemoveObserver(this);
        }
    }
}
