using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the completion of a level when the player enters the trigger area with the required number of collected bananas.
/// </summary>
public class Finish : MonoBehaviour
{
    public CheckpointManager checkpointManager;

    [SerializeField] public BananaTracker bananaTracker;

    /// <summary>
    /// Reference to the ItemCollector script to check the number of collected bananas.
    /// </summary>
    ItemCollector itemCollector;

    /// <summary>
    /// Audio source for the finish sound effect.
    /// </summary>
    AudioSource finishSound;

    /// <summary>
    /// Flag indicating whether the level has been completed.
    /// </summary>
    bool levelCompleted;

    /// <summary>
    /// Reference to the DeathTracker scriptable object for tracking player deaths.
    /// </summary>
    [SerializeField] DeathTracker deathTracker;

    /// <summary>
    /// Called before the first frame update. Initializes component references.
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();

        // Ensure that the ItemCollector is found in the scene
        itemCollector = FindObjectOfType<ItemCollector>();
    }

    /// <summary>
    /// Called when another Collider2D enters the trigger collider.
    /// Checks if the entered object is the player and if the required number of bananas is collected.
    /// Triggers the finish sound, completes the level, and loads the next scene after a delay.
    /// Also reloads death counter for player 
    /// </summary>
    /// <param name="collision">The Collider2D of the entering object.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.tag == "Player" && !levelCompleted && bananaTracker.BananaCount >= 7)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    /// <summary>
    /// Loads the next scene after a delay and resets player checkpoints and banana counts.
    /// </summary>
    void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        checkpointManager.ResetCheckpoint();
        bananaTracker.Reset();
    }
}
