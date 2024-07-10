using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerControllerCT2 : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] GroundCheck groundCheck;
    bool isGound;
    [SerializeField] float Char_speed;
    [SerializeField] float wSpeed;
    [SerializeField] float rSpeed;
    [SerializeField] float jumpForce;
    float horizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //Vector3 loadedPosition = SaveLoadData.LoadPlayerPosition();
        //transform.position = loadedPosition;
    }

    // Update is called once per frame
    void Update()
    {
        isGound = groundCheck.isGround;
        speedControl(rSpeed, wSpeed);
        hMovement(Char_speed);
        Jump();
        checkStatus();
        /* if (Input.GetKeyDown(KeyCode.S))
         {
             SaveLoadData.SavePlayerPosition(transform.position);
       } */
    }

    void hMovement(float speed)
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (horizontal*speed, rb.velocity.y);
        Vector3 characterScale = new (horizontal * 1, 1, 1);
        if(horizontal != 0) transform.localScale = characterScale;
    }



    void speedControl(float runSpeed , float walkSpeed)
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Char_speed = runSpeed;
        }
        else
        {
            Char_speed = walkSpeed;
        }
    }

    void Jump()
    {

        if(Input.GetKeyDown(KeyCode.Space) && isGound)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void checkStatus()
    {
        if (rb.velocity.x != 0)
        {
            animator.SetBool("moving", true);
        }
        else animator.SetBool("moving", false);

        animator.SetBool("isGround", isGound);
    }
}
