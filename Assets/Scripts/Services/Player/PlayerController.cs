using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastMovement;

    public bool isDialogueActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogueActive)
        {
            // Make player stop moving when dialogue is active
            movement = Vector2.zero;
            animator.SetFloat("Speed", 0);
            return;
        }

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (movement != Vector2.zero)
        {
            lastMovement = movement;
        }

        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void UpdateAnimation()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Check if player is not moving
        if (movement == Vector2.zero)
        {
            animator.SetFloat("Horizontal", lastMovement.x);
            animator.SetFloat("Vertical", lastMovement.y);
        }

        // Add footstep effect sound
        if (AudioManager.Instance != null && AudioManager.Instance.effectSource != null)
        {
            if (movement.sqrMagnitude > 0 && !AudioManager.Instance.effectSource.isPlaying)
            {
                AudioManager.Instance.PlaySoundEffect("Footsteps_walking");
            }
            else if (movement.sqrMagnitude == 0 && AudioManager.Instance.effectSource.isPlaying)
            {
                AudioManager.Instance.effectSource.Stop();
            }
        }
    }

    // Block player movement if player meets collider 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}