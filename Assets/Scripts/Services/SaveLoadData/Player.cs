using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public new string name = "test";
    public int level;

    public void SaveData()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;
        name = data.name;
        level = data.level;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

}
