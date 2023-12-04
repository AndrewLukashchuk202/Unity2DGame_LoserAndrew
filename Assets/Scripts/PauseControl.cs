using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls pausing and resuming the game.
/// </summary>
public class PauseControl : MonoBehaviour
{
    /// <summary>
    /// Reference to the PlayerMovement script for managing player movement.
    /// </summary>
    public PlayerMovement player;

    /// <summary>
    /// Reference to the GameObject representing the pause menu.
    /// </summary>
    public GameObject pauseMenu;

    /// <summary>
    /// Flag indicating whether the game is currently paused.
    /// </summary>
    bool paused = false;

    /// <summary>
    /// Update is called once per frame.
    /// Checks for the "Escape" key to toggle between pausing and resuming the game.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    /// <summary>
    /// Pauses the game by setting the time scale to 0, disabling player movement, and activating the pause menu.
    /// </summary>
    void Pause() 
    { 
        paused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        player.enabled = false;
    }

    /// <summary>
    /// Resumes the game by setting the time scale to 1, enabling player movement, and deactivating the pause menu.
    /// </summary>
    public void Resume()
    {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
    }
}
