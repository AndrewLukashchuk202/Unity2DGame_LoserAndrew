using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the functionality of the end menu, such as quitting the application.
/// </summary>
public class EndMenu : MonoBehaviour
{
    /// <summary>
    /// Quits the application.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
