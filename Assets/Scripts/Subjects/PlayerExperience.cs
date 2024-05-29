using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour, IExperienceSubject
{
    private List<IExperienceObserver> observers = new List<IExperienceObserver>();
    private int experience;
    public int currentLevel = 1;

    public int Experience
    {
        get { return experience; }
        set
        {
            experience = value;
            NotifyObservers();
        }
    }

    public int CurrentLevel
    {
        get { return currentLevel; }
        set
        {
            currentLevel = value;
            NotifyObservers();
        }
    }

    public void ChangeExperience(int amount)
    {
        experience += amount;
        if (experience > 100)
        {
            experience = 0;
            currentLevel++;
        }

        Experience = experience;
        CurrentLevel = currentLevel;

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
