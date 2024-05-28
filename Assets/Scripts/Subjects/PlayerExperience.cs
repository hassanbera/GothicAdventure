using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour, IExperienceSubject
{
    private List<IExperienceObserver> observers = new List<IExperienceObserver>();
    private int experience;

    public int Experience
    {
        get { return experience; }
        set
        {
            experience = value;
            NotifyObservers();
        }
    }

    public void RegisterObserver(IExperienceObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IExperienceObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (IExperienceObserver observer in observers)
        {
            observer.OnExperienceChanged(experience);
        }
    }
}
