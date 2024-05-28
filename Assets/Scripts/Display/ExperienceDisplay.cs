using UnityEngine;
using UnityEngine.UI;

public class ExperienceDisplay : MonoBehaviour, IExperienceObserver
{
    public Text experienceText;

    public void OnExperienceChanged(int experience)
    {
        experienceText.text = "Experience: " + experience;
    }

    private void Start()
    {
        PlayerExperience playerExperience = FindObjectOfType<PlayerExperience>();
        playerExperience.RegisterObserver(this);
    }

    private void OnDestroy()
    {
        PlayerExperience playerExperience = FindObjectOfType<PlayerExperience>();
        if (playerExperience != null)
        {
            playerExperience.RemoveObserver(this);
        }
    }
}
