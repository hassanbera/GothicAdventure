using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicController : MonoBehaviour
{
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Main Menu":
                AudioManager.instance.PlayMusic(AudioManager.instance.mainMenuMusic);
                break;
            case "LevelSelection":
                AudioManager.instance.PlayMusic(AudioManager.instance.mainMenuMusic);
                break;
            case "Level 1":
                AudioManager.instance.PlayMusic(AudioManager.instance.level1Music);
                break;
            case "Level 2":
                AudioManager.instance.PlayMusic(AudioManager.instance.level2Music);
                break;
            case "Level 3":
                AudioManager.instance.PlayMusic(AudioManager.instance.level3Music);
                break;
        }
    }
}
