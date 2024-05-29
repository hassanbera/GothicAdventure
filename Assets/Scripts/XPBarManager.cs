using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPBarManager : MonoBehaviour,IExperienceObserver
{
    public Image xpBar;
    public TextMeshProUGUI xpText;
    public PlayerExperience playerExperience;
    // Start is called before the first frame update
    void Start()
    {
        playerExperience = GameObject.FindObjectOfType<PlayerExperience>();
        playerExperience.RegisterObserver(this);

        xpBar.fillAmount = playerExperience.Experience / 100;
        xpText.text = "XP lvl" + playerExperience.CurrentLevel;
    }

    // Update is called once per frame
    

    void updateXPBar(int value)
    {
        // convert the value from int to float
        float xp = value;
        xpBar.fillAmount = xp / 100;
        xpText.text = "XP lvl" + playerExperience.CurrentLevel;
        Debug.Log("XP: " + value);
    
    }

    public void OnExperienceChanged(int value)
    {
        updateXPBar(value);
    }
}
