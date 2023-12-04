using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the functionality of the start menu, such as starting the game.
/// </summary>
public class StartMenu : MonoBehaviour
{
    /// <summary>
    /// Starts the game by loading the next scene.
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Quits the game when called.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
