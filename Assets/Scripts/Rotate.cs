using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates the game object around its z-axis at a specified speed.
/// </summary>
public class Rotate : MonoBehaviour
{
    /// <summary>
    /// The rotation speed of the game object.
    /// </summary>
    [SerializeField] float speed = 2f;

    /// <summary>
    /// Called once per frame. Rotates the game object around its z-axis based on the specified speed.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        // Rotate the game object around its z-axis
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
