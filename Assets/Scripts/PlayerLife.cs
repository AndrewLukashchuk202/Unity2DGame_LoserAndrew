using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages the player's life, triggering death and restarting the level when encountering traps.
/// </summary>
public class PlayerLife : MonoBehaviour
{



    //public GameObject playerPrefab; // Reference to your player prefab

    /// <summary>
    /// The Rigidbody2D component of the player.
    /// </summary>
    Rigidbody2D rb;

    /// <summary>
    /// The UI text element displaying the player's death count.
    /// </summary>
    [SerializeField] Text deathText;

    /// <summary>
    /// Reference to the DeathTracker scriptable object for tracking player deaths.
    /// </summary>
    [SerializeField] DeathTracker deathTracker;


    /// <summary>
    /// The UI text element displaying the player's banana count.
    /// </summary>
    [SerializeField] Text bananaText;


    /// <summary>
    /// Reference to the BananaTracker scriptable object for tracking player's collected bananas.
    /// </summary>
    [SerializeField] BananaTracker bananaTracker;

    /// <summary>
    /// Reference to the respawn controller responsible for handling player respawning.
    /// </summary>
    [SerializeField] RespawnControl respawnControl;

    /// <summary>
    /// The Animator component of the player.
    /// </summary>
    Animator animator;

    /// <summary>
    /// The audio source for the death sound effect.
    /// </summary>
    [SerializeField] AudioSource deathSoundEffect;

    /// <summary>
    /// Called before the first frame update. Initializes component references.
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        deathText = GameObject.Find("Death Text").GetComponent<Text>();
        bananaText = GameObject.Find("Bananas Text").GetComponent<Text>();
        respawnControl = GameObject.Find("Respawner").GetComponent<RespawnControl>();
        deathText.text = ":"  + deathTracker.DeathCount.ToString();
        bananaText.text = ":" + bananaTracker.BananaCount.ToString() + "/7";
    }

    /// <summary>
    /// Called when a Collider2D enters the player's collider.
    /// Checks if the entered object is a trap and triggers death if true.
    /// </summary>
    /// <param name="collision">The Collision2D data of the entering object.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    /// <summary>
    /// Triggers player death, plays the death sound effect, and sets the player to a static state.
    /// </summary>
    void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");

        deathTracker.AddDeath();
        deathText.text = ":" + deathTracker.DeathCount.ToString();

    }

    /// <summary>
    /// Restarts the current level.
    /// </summary>
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    /// <summary>
    /// Called to spawn a new player object using the respawn controller.
    /// </summary>
    void SpawnPlayer()
    {
        // Instantiate a new player GameObject from the prefab
        respawnControl.Respawn();
    }

    /// <summary>
    /// Respawns the player by destroying the current player object and spawning a new one.
    /// </summary>
    public void RespawnPlayer()
    {
        // Destroy the current player GameObject
        Destroy(gameObject);

        SpawnPlayer();
    }
}
