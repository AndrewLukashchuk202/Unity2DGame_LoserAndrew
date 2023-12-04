using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes checkpoints and sets up the CheckpointManager with the checkpoint list.
/// </summary>
public class InitialiseCheckpoints : MonoBehaviour
{
    /// <summary>
    /// Reference to the CheckpointManager responsible for managing checkpoints.
    /// </summary>
    public CheckpointManager manager;

    /// <summary>
    /// List of checkpoint Transforms created during initialization.
    /// </summary>
    List<Transform> checkpointList = new List<Transform>();

    /// <summary>
    /// Called when the script instance is being loaded.
    /// Initializes checkpoints and sets up the CheckpointManager.
    /// </summary>
    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform currentPoint = transform.GetChild(i);
            bool pointPassed = (i <= manager.currentCheckpoint) ? true : false;
            checkpointList.Add(currentPoint.GetComponent<CheckpointControl>().Initialise(i, pointPassed));
        }

        manager.Initialise(checkpointList);
    }
}
