using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOtherObjectMaterialOnTrigger : MonoBehaviour
{
    public GameObject objection;
    private Material oldMaterial;
    public Material newMaterial;

    private void Start()
    {
        oldMaterial = objection.GetComponent<SpriteRenderer>().material;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            objection.GetComponent<SpriteRenderer>().material = newMaterial;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            objection.GetComponent<SpriteRenderer>().material = oldMaterial;
        }
    }

}
