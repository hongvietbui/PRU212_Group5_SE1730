using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    private float startPos ,Length;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform .position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance  = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * (1- parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        if(movement > startPos + Length) {
            startPos += Length;
        }else if(movement < startPos - Length)
        {
            startPos -= Length;
        }
    }
}
