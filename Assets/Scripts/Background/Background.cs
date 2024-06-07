using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    public bool infiniteHorizontal = true;
    public bool infiniteVertical = false;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (infiniteHorizontal)
        {
            if (temp > startpos + length) startpos += length;
            else if (temp < startpos - length) startpos -= length;
        }

        if (infiniteVertical)
        {
            float tempY = (cam.transform.position.y * (1 - parallaxEffect));
            float distY = (cam.transform.position.y * parallaxEffect);

            transform.position = new Vector3(transform.position.x, startpos + distY, transform.position.z);

            if (tempY > startpos + length) startpos += length;
            else if (tempY < startpos - length) startpos -= length;
        }
    }
}
