using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int health;
    public string name;
    public int level;
    public float[] position;

    public PlayerData(Player player)
    {
        health = player.health;
        name = player.name;
        level = player.level;

        Vector3 playerPos = player.transform.position;

        position = new float[]
        {
            playerPos.x, playerPos.y, playerPos.z
        };
    }
}
