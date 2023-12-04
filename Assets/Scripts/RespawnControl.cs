using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the respawn functionality by instantiating a new player object at the current checkpoint.
/// </summary>
public class RespawnControl : MonoBehaviour
{
    /// <summary>
    /// Reference to the checkpoint manager responsible for tracking the player's progress.
    /// </summary>
    public CheckpointManager checkpoints;

    /// <summary>
    /// The player prefab to be instantiated upon respawn.
    /// </summary>
    public GameObject playerPrefab;

    /// <summary>
    /// Reference to the camera controller for assigning the player to the camera's follow target.
    /// </summary>
    public CameraController cameraController;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// Initializes the camera controller reference.
    /// </summary>
    private void Start()
    {
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();    
    }

    /// <summary>
    /// Respawns the player by instantiating a new player object at the current checkpoint position.
    /// Also assigns the "Player" tag to the instantiated player object.
    /// </summary>
    public void Respawn()
    {
        cameraController.AssignPlayer(Instantiate(playerPrefab, checkpoints.GetCurrentCheckpoint().position, Quaternion.identity).transform);
        // we assign tag - "Player" to a new created object of type Player because other object such as: moving platforms, finish would not see this object - Player
        playerPrefab.tag = "Player";
    }
}
