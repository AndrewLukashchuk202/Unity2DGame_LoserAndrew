using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the movement and animation of the player character.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    // Player's Components
    // Rigidbody2D rigidbody - handles the physics of the game object
    // BoxCollider2D collider - defines the shape of of the collider attached to the game object
    // SpriteRenderer spriteRenderer - component is responsible for rendering the visual representation of the game object
    // Animator animator - component is used for controlling animations
    Rigidbody2D rigidbody;
    BoxCollider2D collider;
    SpriteRenderer spriteRenderer;
    Animator animator;

    [Header("Spawning")]
    public CheckpointManager checkpointManager;

    // Layer Mask to see if object Player can jump or not
    [SerializeField] LayerMask jumpableGround;

    // Movement parameters
    // dirX - defines which direction object Player is facing 
    // moveSpeed - determines the movement speed at which the player moves
    //jumpForce - determines the movements speed at which the player jumps
    float dirX = 0f;
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float jumpForce = 20f;

    // Unique list with prepared objects inside to define what the object Player is doing at the moment.
    // enum lists is needed for defining animations for the object Player based on what player is doing
    enum MovementState {idle, running, jumping, falling}

    // Sound effects - when object Player jumps
    [SerializeField] AudioSource jumpSoundEffect;

    /// <summary>
    /// Called before the first frame update.
    /// Initializes component references.
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Transform currentCheckpoint = checkpointManager.GetCurrentCheckpoint();
        if (currentCheckpoint != null)
        {
            transform.position = currentCheckpoint.position;
        }
    }

    /// <summary>
    /// Called once per frame.
    /// Updates player movement and animation.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState();
    }

    /// <summary>
    /// Updates the animation state of the player based on input and physics. 
    /// First we get pressed keys - (input from player) then we define speed and direction for the object - Player
    /// </summary>
    private void UpdateAnimationState()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(dirX * moveSpeed, rigidbody.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSoundEffect.Play();
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }

        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rigidbody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rigidbody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    // <summary>
    /// Checks if the player is grounded.
    /// </summary>
    /// <returns>True if the player is grounded, false otherwise.</returns>
    bool isGrounded()
    {
       return  Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
