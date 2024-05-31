using System.Collections.Generic;

using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealthSubject
{
    private List<IHealthObserver> observers = new List<IHealthObserver>();
    private float health = 100;
    private float maxHealth = 100;

    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            NotifyObservers();
        }
    }

    public void changeHealth(float amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
            Die();
        }

        Health = health;
    }

    public void RegisterObserver(IHealthObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IHealthObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IHealthObserver observer in observers)
        {
            observer.OnHealthChanged(health);
        }
    }

    public void Die()
    {
        // respawn player and reset health
        health = maxHealth;
        NotifyObservers();

        // respawn player
        GameManager.instance.RespawnPlayer(GetComponent<PlayerController>());
    }
}
