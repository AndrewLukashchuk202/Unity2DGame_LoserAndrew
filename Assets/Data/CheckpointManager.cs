using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// ScriptableObject to manage and track player checkpoints in the game.
/// </summary>
[CreateAssetMenu()]
public class CheckpointManager : ScriptableObject
{
    /// <summary>
    /// Index of the current checkpoint in the spawnPoints list.
    /// </summary>
    public int currentCheckpoint;

    /// <summary>
    /// List of spawn points representing checkpoints in the game.
    /// </summary>
    public List<Transform> spawnPoints = new List<Transform>();

    /// <summary>
    /// Initializes the checkpoint manager with a new list of spawn points.
    /// </summary>
    /// <param name="newSpawnPoints">List of spawn points to set as checkpoints.</param>
    public void Initialise(List<Transform> newSpawnPoints)
    {
        spawnPoints.Clear();
        spawnPoints = newSpawnPoints;
    }

    /// <summary>
    /// Updates the current checkpoint index to the specified checkpoint.
    /// </summary>
    /// <param name="newCheckpoint">Index of the new checkpoint.</param>
    public void UpdateCheckpoint(int newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
    }

    /// <summary>
    /// Retrieves the Transform of the current checkpoint.
    /// </summary>
    /// <returns>Transform of the current checkpoint, or null if no checkpoints are available.</returns>
    public Transform GetCurrentCheckpoint()
    {
        if(spawnPoints.Count > 0)
        {
            return spawnPoints[currentCheckpoint];
        }
        return null;
    }

    /// <summary>
    /// Resets the current checkpoint index to the default (usually the first checkpoint).
    /// </summary>  
    public void ResetCheckpoint()
    {
        currentCheckpoint = 0;
    }
}
