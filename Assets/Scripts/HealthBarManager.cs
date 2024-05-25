using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarManager : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public Image healthBar;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = health + "%";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            updateHealthBar(-10);
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            updateHealthBar(10);
        }
    }

    // we can pass positive or negative value to this function
    public void updateHealthBar(float value)
    {
        health += value;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        if(health < 0)
        {
            health = 0;
        }
        healthBar.fillAmount = health / maxHealth;
        healthText.text = health + "%";
    
    }
}
