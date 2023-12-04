using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class - makes the player stick to the platform when entering the trigger and releases them when exiting.
/// </summary>
public class StickyPlatform : MonoBehaviour
{
    /// <summary>
    /// Called when another Collider2D enters the trigger collider.
    /// Sets the player as a child of the platform to make them stick.
    /// </summary>
    /// <param name="collision">The Collider2D of the entering object.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.tag == "Player")
        {
            // Set the player as a child of the platform
            collision.gameObject.transform.SetParent(transform);
        }
    }

    /// <summary>
    /// Called when another Collider2D exits the trigger collider.
    /// Releases the player from being a child of the platform.
    /// </summary>
    /// <param name="collision">The Collider2D of the exiting object.</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.tag == "Player")
        {
            // Release the player from being a child of the platform
            collision.gameObject.transform.SetParent(null);
        }
    }
}
