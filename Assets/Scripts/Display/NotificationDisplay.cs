using UnityEngine;
using UnityEngine.UI;

public class NotificationDisplay : MonoBehaviour, INotificationObserver
{
    public Text notificationText;

    public void OnNotificationReceived(string message)
    {
        notificationText.text = message;
    }

    private void Start()
    {
        NotificationCenter notificationCenter = FindObjectOfType<NotificationCenter>();
        notificationCenter.RegisterObserver(this);
    }

    private void OnDestroy()
    {
        NotificationCenter notificationCenter = FindObjectOfType<NotificationCenter>();
        if (notificationCenter != null)
        {
            notificationCenter.RemoveObserver(this);
        }
    }
}
