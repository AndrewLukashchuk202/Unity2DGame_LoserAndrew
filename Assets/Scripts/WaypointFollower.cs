using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that controls movements of the game object along a series of waypoints in a loop.
/// </summary>
public class WaypointFollower : MonoBehaviour
{
    // <summary>
    /// The waypoints to follow.
    /// </summary>
    [SerializeField] GameObject[] waypoints;

    /// <summary>
    /// The index of the current waypoint in the waypoints array.
    /// </summary>
    int currentWaypointIndex = 0;

    /// <summary>
    /// The speed at which the game object moves between waypoints.
    /// </summary>
    [SerializeField] float speed = 2f;

    /// <summary>
    /// Called once per frame. Updates the game object's position to move towards the current waypoint.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        // Check if the game object is close to the current waypoint
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            // Move to the next waypoint
            currentWaypointIndex++;

            // If the end of the waypoints array is reached, loop back to the first waypoint
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        // Move the game object towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
