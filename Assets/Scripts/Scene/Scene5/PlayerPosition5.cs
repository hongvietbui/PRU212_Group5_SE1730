using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition5 : MonoBehaviour
{
    public Transform playerTransform;
	void Start()
    {
        playerTransform.position = PuzzleState.savedPosition;
    }
}
