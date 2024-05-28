using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour, IHealthObserver
{
    public Text healthText;

    public void OnHealthChanged(int health)
    {
        healthText.text = "Health: " + health;
    }

    private void Start()
    {
        // Assuming the Player GameObject has the PlayerHealth component
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        playerHealth.RegisterObserver(this);
    }

    private void OnDestroy()
    {
        // Unregister this observer when destroyed
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.RemoveObserver(this);
        }
    }
}
