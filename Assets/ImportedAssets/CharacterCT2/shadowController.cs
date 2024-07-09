using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowController : MonoBehaviour
{
    //Rigidbody2D rb;
    //Animator animator;
    [SerializeField] GameObject player;
    //[SerializeField] GroundCheck groundCheck;
    //bool isGround;

    //private void Awake()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    animator = GetComponent<Animator>();
    //}

    // Update is called once per frame
    void Update()
    {
        //isGround = groundCheck.isGround;
        Vector3 playerPosition = player.transform.position;
        Vector3 playerLocalScale = player.transform.localScale;

        transform.position = new Vector3(playerPosition.x , -playerPosition.y , playerPosition.z);

        transform.localScale = new Vector3 (playerLocalScale.x , -playerLocalScale.y,playerLocalScale.z);

        //checkStatus();
        
    }

    //void checkStatus()
    //{
    //    if (rb.velocity.x != 0)
    //    {
    //        animator.SetBool("moving", true);
    //    }
    //    else animator.SetBool("moving", false);



    //    animator.SetBool("isGround", isGround);

    //    Debug.Log(isGround);
    //}

}
