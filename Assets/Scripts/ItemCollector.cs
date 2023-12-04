using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Collects bananas and updates the UI and audio when a banana is collected.
/// </summary>
public class ItemCollector : MonoBehaviour
{
    /// <summary>
    /// Reference to the BananaTracker scriptable object for tracking banana counts.
    /// </summary>
    [SerializeField] BananaTracker bananaTracker;

    /// <summary>
    /// Reference to the PlayerLife script for handling player life-related actions.
    /// </summary>
    [SerializeField] PlayerLife playerLife;


    // <summary>
    /// The UI Text element to display the banana count.
    /// </summary>
    [SerializeField] Text bananasText;

    /// <summary>
    /// The audio source for the collection sound effect.
    /// </summary>
    [SerializeField] AudioSource collectionSoundEffect;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// Initializes references to external components.
    /// </summary>
    private void Start()
    {
        bananasText = GameObject.Find("Bananas Text").GetComponent<Text>();
    }

    /// <summary>
    /// Called when another Collider2D enters the trigger collider.
    /// Checks if the entered object is a banana and updates the count, UI, and audio accordingly.
    /// </summary>
    /// <param name="collision">The Collider2D of the entering object.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //bananasText = GameObject.Find("Bananas Text").GetComponent<Text>();

        if (collision.gameObject.CompareTag("Banana"))
        {
            collectionSoundEffect.Play();
            bananaTracker.AddBanana();
            Destroy(collision.gameObject);
            bananasText.text = ":" + bananaTracker.BananaCount.ToString() + "/7";
        }   
    }
}
