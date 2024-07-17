using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    public float moveSpeed = 5f;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    private InputManager inputManager;
    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        inputManager = InputManager.Instance;
    }

    void FixedUpdate()
    {
        // Check if the pause menu is active
        if (PauseMenuManager.Instance.pauseMenuCanvas.activeSelf)
        {
            // If the pause menu is active, stop the player's movement
            rb.velocity = Vector2.zero;
            return;
        }

        //// Get horizontal input
        //horizontalInput = Input.GetAxis("Horizontal");

        //// Flip the sprite based on the input direction
        //spriteRenderer.flipX = horizontalInput < 0;

        //// Apply movement to the rigidbody
        //rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
}
