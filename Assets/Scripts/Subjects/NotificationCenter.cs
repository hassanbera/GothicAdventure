using System.Collections.Generic;
using UnityEngine;

public class NotificationCenter : MonoBehaviour, INotificationSubject
{
    private List<INotificationObserver> observers = new List<INotificationObserver>();

    public void RegisterObserver(INotificationObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(INotificationObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(string message)
    {
        foreach (INotificationObserver observer in observers)
        {
            observer.OnNotificationReceived(message);
        }
    }
}
