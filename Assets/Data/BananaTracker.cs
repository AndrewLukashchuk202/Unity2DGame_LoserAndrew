using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ScriptableObject for tracking the number of collected bananas.
/// </summary>
[CreateAssetMenu]
public class BananaTracker : ScriptableObject
{
    /// <summary>
    /// Current count of collected bananas.
    /// </summary>
    [SerializeField] int bananaCount = 0;

    /// <summary>
    /// Gets the current count of collected bananas.
    /// </summary>
    public int BananaCount { get { return bananaCount; } }

    /// <summary>
    /// Resets the banana count to zero.
    /// </summary>
    public void Reset()
    {
        bananaCount = 0;
    }

    /// <summary>
    /// Increments the banana count when a banana is collected.
    /// </summary>
    public void AddBanana()
    {
        bananaCount++;
    }
}
