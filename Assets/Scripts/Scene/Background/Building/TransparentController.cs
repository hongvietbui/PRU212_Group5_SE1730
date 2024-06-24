using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyController : MonoBehaviour
{
    public GameObject building;
    private Material buildingMaterial;
    public float transparentAlpha = 0.5f;

    void Start()
    {
        buildingMaterial = building.GetComponent<Renderer>().material;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Color color = buildingMaterial.color;
            color.a = transparentAlpha;
            buildingMaterial.color = color;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Color color = buildingMaterial.color;
            color.a = 1f;
            buildingMaterial.color = color;
        }
    }
}

