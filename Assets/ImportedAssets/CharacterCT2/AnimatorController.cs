using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator animatorPlayer;
    public Animator animatorShadow; 

    void Update()
    {
        if (animatorPlayer && animatorShadow)
        {
        
            bool isGround = animatorPlayer.GetBool("isGround");
            animatorShadow.SetBool("isGround", isGround);

            bool moving = animatorPlayer.GetBool("moving");
            animatorShadow.SetBool("moving", moving);
        }
    }
}
