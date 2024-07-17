using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByComputer : MonoBehaviour
{

    private bool isInRange = false;


    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Scene5_ExitClassroom");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
}
