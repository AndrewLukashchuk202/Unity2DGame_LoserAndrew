using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls individual checkpoints, updating the CheckpointManager when a player passes through.
/// </summary>
public class CheckpointControl : MonoBehaviour
{
    /// <summary>
    /// Index of the checkpoint in the CheckpointManager's list.
    /// </summary>
    [SerializeField] int checkpointIndex = 0;

    /// <summary>
    /// Flag indicating whether the player has passed through this checkpoint.
    /// </summary>
    [SerializeField] bool checkpointPassed = false;

    /// <summary>
    /// Reference to the CheckpointManager responsible for managing checkpoints.
    /// </summary>
    [SerializeField] CheckpointManager manager;

    /// <summary>
    /// Initializes the checkpoint with the specified index and passed status.
    /// </summary>
    /// <param name="index">Index of the checkpoint.</param>
    /// <param name="passed">Whether the checkpoint has been passed.</param>
    /// <returns>Transform of the checkpoint.</returns>
    public Transform Initialise(int index, bool passed)
    {
        checkpointIndex = index;
        checkpointPassed = passed;
        return transform.GetChild(0);
    }

    /// <summary>
    /// Called when another Collider2D enters the trigger collider.
    /// Checks if the entering object is the player and updates the checkpoint state.
    /// </summary>
    /// <param name="collision">The Collider2D of the entering object.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !checkpointPassed)
        {
            checkpointPassed = true;
            manager.UpdateCheckpoint(checkpointIndex);
        }
    }
}
