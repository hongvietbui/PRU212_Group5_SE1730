using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    [SerializeField] Transform GroundCheckBox;
    [SerializeField] LayerMask ground;
    public bool isGround;
    Vector2 center;
    Vector2 size;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        size = new (0.8f, 0.31f);
        center = GroundCheckBox.position;

        isGround = Physics2D.OverlapBox(center, size,0,ground);
    }


}
