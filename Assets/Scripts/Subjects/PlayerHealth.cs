using System.Collections.Generic;

using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealthSubject
{
    private List<IHealthObserver> observers = new List<IHealthObserver>();
    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            NotifyObservers();
        }
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
}
