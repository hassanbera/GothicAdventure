using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPBarManager : MonoBehaviour
{
    public float xp = 0;
    public float maxXp = 100;
    public Image xpBar;
    public float currentLevel = 1;
    public TextMeshProUGUI xpText;
    // Start is called before the first frame update
    void Start()
    {
        xpText.text = "XP lvl" + currentLevel;

        updateXPBar(0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.O))
        {
            updateXPBar(10);
        }
    }

    void updateXPBar(float value)
    {
        xp += value;
        if(xp > maxXp)
        {
            xp = 0;
            currentLevel++;
        }
        xpBar.fillAmount = xp / maxXp;
        xpText.text = "XP lvl" + currentLevel;   
    
    }
}
