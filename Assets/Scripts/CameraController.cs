using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the position of the camera to follow a specified player's transform.
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// The transform of the player to follow.
    /// </summary>
    [SerializeField] Transform player;


    private void Start()
    {
        // Find the player dynamically
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }
    /// <summary>
    /// Called once per frame. Updates the camera position to follow the player.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        // Check if the player is found
        if (player != null)
        {
            // Update the camera position to follow the player
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
    }

    public void AssignPlayer(Transform player)
    {
        this.player = player;
    }
}
