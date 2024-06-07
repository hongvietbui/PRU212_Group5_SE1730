using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float FollowSpeed = 2f;
    public Transform Target;
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos =  new Vector3(Target.position.x,-1f,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
    }
}
