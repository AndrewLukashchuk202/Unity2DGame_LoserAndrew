using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles quitting the game.
/// </summary>
public class QuitGame : MonoBehaviour
{
    /// <summary>
    /// Quits the game when called.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
