using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManagement : MonoBehaviour
{
    public void ClearData() {
        List<Item> items = new List<Item>();

        SaveLoadData.SaveInventory(items);
    }
}
