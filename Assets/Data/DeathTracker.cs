using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// A ScriptableObject used for tracking player deaths in a Unity game.
/// </summary>
[CreateAssetMenu]
public class DeathTracker : ScriptableObject
{
    /// <summary>
    /// The current count of player deaths.
    /// </summary>
    [SerializeField] int deathCount = 0;

    /// <summary>
    /// Gets the current count of player deaths.
    /// </summary>
    public int DeathCount { get { return deathCount; } }

    /// <summary>
    /// Resets the death count to zero.
    /// </summary>
    public void Reset()
    {
        deathCount = 0;
    }

    /// <summary>
    /// Increments the death count by one, indicating a player death.
    /// </summary>
    public void AddDeath()
    {
        deathCount++;
    }
}
