using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    

    // Method to start the game
    public void PlayGame()
    {
        // Replace "Level1" with the name of your first level scene
        SceneManager.LoadScene("Level 1");
    }

    // Method to quit the game
    public void QuitGame()
    {
        // Quits the application
        Application.Quit();
        #if UNITY_EDITOR
        // Stop playing the scene in the editor
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    // Method to go to the levels selection screen
    public void GoToLevels()
    {
        // Replace "LevelSelection" with the name of your levels selection scene
        SceneManager.LoadScene("LevelSelection");
    }
}
