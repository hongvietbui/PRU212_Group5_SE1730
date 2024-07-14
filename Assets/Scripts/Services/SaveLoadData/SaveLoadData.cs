using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;
public class SaveLoadData : MonoBehaviour
{

    
    public static void SaveInventory(List<Item> items)
    {
        string filePath = Application.persistentDataPath + "/inventory.json";
        List<ItemData> itemDataList = new List<ItemData>();
        foreach (var item in items)
        {
            itemDataList.Add(ItemConverter.ToItemData(item));
        }
        string json = JsonUtility.ToJson(new Serialization<ItemData>(itemDataList), true);
        File.WriteAllText(filePath, json);
        Debug.Log("Inventory saved to " + filePath);
    }

    public static List<Item> LoadInventory()
    {
        string filePath = Application.persistentDataPath + "/inventory.json";
        if (File.Exists(filePath))
        {
            List<Item> items = new List<Item>();
            string json = File.ReadAllText(filePath);
            Serialization<ItemData> itemDataList = JsonUtility.FromJson<Serialization<ItemData>>(json);
            foreach (var data in itemDataList.items)
            {
                items.Add(ItemConverter.ToItem(data));
            }
            return items;
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            return null;

        }
    }

    public static void SavePlayerPosition(Vector3 position)
    {
        string filePath = Application.persistentDataPath + "/playerPosition.json";
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);
        PlayerPosition playerPosition = new PlayerPosition(position, sceneName);
        string json = JsonUtility.ToJson(playerPosition);
        File.WriteAllText(filePath, json);
    }

    public static PlayerPosition LoadPlayerPosition()
    {
        string filePath = Application.persistentDataPath + "/playerPosition.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerPosition playerPosition = JsonUtility.FromJson<PlayerPosition>(json);
            return playerPosition;
        }
        return null; 
    }

}

[System.Serializable]
public class Serialization<T>
{
    public List<T> items;
    public Serialization(List<T> items)
    {
        this.items = items;
    }
}

[System.Serializable]
public class PlayerPosition
{
    public float x;
    public float y;
    public float z;
    public string sceneName;

    public PlayerPosition(Vector3 position, string sceneName)
    {
        x = position.x;
        y = position.y;
        z = position.z;
        this.sceneName = sceneName;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}