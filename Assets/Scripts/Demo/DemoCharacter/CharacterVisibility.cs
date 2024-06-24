using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class CharacterVisibility : MonoBehaviour
{
    public GameObject player; // Ref to the player object
    public GameObject building; // Ref to the obstacle object
    private Renderer buildingRenderer;
    private Renderer playerRenderer;
    private Material buildingOriginalMaterial;
    public Material transparentMaterial; // transparent material

    void Start()
    {
        buildingRenderer = building.GetComponent<Renderer>();
        playerRenderer = player.GetComponent<Renderer>();
        buildingOriginalMaterial = buildingRenderer.material;
    }

    void Update()
    {
        if (player.transform.position.z < building.transform.position.z)
        {
            // Make building transparent and player visible
            buildingRenderer.material = transparentMaterial;

            // Turn on the outline of the player
            playerRenderer.material.SetFloat("_Outline", 1.0f);
        }
        else
        {
            // Make building opaque and player invisible
            buildingRenderer.material = buildingOriginalMaterial;

            // Turn off the outline of the player
            playerRenderer.material.SetFloat("_Outline", 0.0f);
        }
    }
}

