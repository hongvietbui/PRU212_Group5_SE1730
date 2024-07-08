using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float crouchSpeedMultiplier = 0.5f; // Speed multiplier when crouching
    public float jumpForce = 10f; // Force applied when jumping

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastMovement;
    private bool isCrouching = false;
    private bool wasCrouching = false;

    public bool isDialogueActive = false;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDialogueActive)
        {
            // Make player stop moving when dialogue is active
            movement = Vector2.zero;
            animator.SetFloat("Speed", 0);
            return;
        }

        // Toggle crouch state
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;
        }

        // Check if crouching state has changed
        if (isCrouching != wasCrouching)
        {
            if (isCrouching)
            {
                // Reduce speed when crouching
                speed *= crouchSpeedMultiplier;
            }
            else
            {
                // Restore speed when standing up from crouch
                speed /= crouchSpeedMultiplier;
            }
            wasCrouching = isCrouching;
        }

        // Read movement input
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (movement != Vector2.zero)
        {
            lastMovement = movement;
        }

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        UpdateAnimation();
    }

    void FixedUpdate()
    {
        // Apply movement
        rigidbody2D.velocity = movement * speed * Time.deltaTime;
    }

    void UpdateAnimation()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        animator.SetFloat("Speed", movement.magnitude);

        // Check if player is not moving
        if (movement == Vector2.zero)
        {
            animator.SetFloat("Horizontal", lastMovement.x);
            animator.SetFloat("Vertical", lastMovement.y);
        }

        // Play footsteps sound effect
        if (movement.magnitude > 0 && !AudioManager.Instance.effectSource.isPlaying)
        {
            AudioManager.Instance.PlaySoundEffect("Footsteps_walking");
        }
        else if (movement.magnitude == 0 && AudioManager.Instance.effectSource.isPlaying)
        {
            AudioManager.Instance.effectSource.Stop();
        }

        // You can optionally add logic here for other animations or effects
    }

    void Jump()
    {
        // Check if grounded (you may need a GroundCheck for this)
        // For simplicity, assume the player can always jump for now
        rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Block player movement if colliding with an obstacle
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
    