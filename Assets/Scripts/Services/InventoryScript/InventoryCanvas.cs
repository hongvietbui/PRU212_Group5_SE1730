using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{
    private static InventoryCanvas instance;

    public static InventoryCanvas Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryCanvas>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ShowInventory()
    {
        gameObject.SetActive(true);
    }

    public void HideInventory()
    {
        gameObject.SetActive(false);
    }
}
