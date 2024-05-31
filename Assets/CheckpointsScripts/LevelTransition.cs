using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Load the next scene in the build order
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            // Check if there is a next scene in the build order
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("This is the last scene in the build order.");
                // Optionally, reload the current scene or go to a specific end scene
                // SceneManager.LoadScene(currentSceneIndex); // to reload
                // SceneManager.LoadScene("EndScene"); // to load a specific end scene
            }
        }
    }
}

