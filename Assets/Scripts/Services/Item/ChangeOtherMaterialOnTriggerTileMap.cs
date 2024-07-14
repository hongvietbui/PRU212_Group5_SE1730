using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeOtherMaterialOnTriggerTileMap : MonoBehaviour
{
    public GameObject objection;
    private Material oldMaterial;
    public Material newMaterial;
    private TilemapRenderer tilemapRenderer;

    private void Start()
    {
        tilemapRenderer = objection.GetComponent<TilemapRenderer>();
        if (tilemapRenderer != null)
        {
            oldMaterial = tilemapRenderer.material;
        }
        else
        {
            Debug.LogError("No TilemapRenderer found on the object.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (tilemapRenderer != null)
            {
                tilemapRenderer.material = newMaterial;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (tilemapRenderer != null)
            {
                tilemapRenderer.material = oldMaterial;
            }
        }
    }
}
