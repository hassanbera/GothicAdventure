using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarManager : MonoBehaviour, IHealthObserver
{
    public Image healthBar;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    public PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
        playerHealth.RegisterObserver(this);

        healthBar.fillAmount = playerHealth.Health / 100;
        healthText.text = playerHealth.Health.ToString() + " HP";
    }

    public void updateHealthBar(float health)
    {
        healthBar.fillAmount = health / 100;
        healthText.text = health.ToString() + " HP";
        Debug.Log("Health: " + health);
    }

    public void OnHealthChanged(float health)
    {
        updateHealthBar(health);
    }
}
