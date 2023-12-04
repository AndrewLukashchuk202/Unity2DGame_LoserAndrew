using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Restarts the current level by resetting the banana count and reloading the scene.
/// </summary>
public class RestartLevel : MonoBehaviour
{
    /// <summary>
    /// Reference to the PauseControl script for managing game pause/resume.
    /// </summary>
    public PauseControl pauseControl;

    /// <summary>
    /// Reference to the BananaTracker scriptable object for tracking banana counts.
    /// </summary>
    public BananaTracker bananaTracker;

    /// <summary>
    /// Restarts the current level by resetting the banana count, reloading the scene, and resuming the game.
    /// </summary>
    public void Restart()
    {
        bananaTracker.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pauseControl.Resume();
    }
}
