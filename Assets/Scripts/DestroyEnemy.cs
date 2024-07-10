using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    // Reference to the enemy GameObject
    public GameObject enemy;

    public void DestroyEnemyObject()
    {
        if (enemy != null)
        {
            Destroy(enemy);
        }
        else
        {
            Debug.LogWarning("Enemy GameObject is not assigned or already destroyed.");
        }
    }
}
