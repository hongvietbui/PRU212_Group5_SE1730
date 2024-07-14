using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {

        LoadPlayerPosition();
    }

    private void OnApplicationQuit()
    {
        SaveLoadData.SavePlayerPosition(player.transform.position);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SaveLoadData.SavePlayerPosition(player.transform.position);
            Debug.Log("V");
        }
    }


    public void LoadPlayerPosition()
    {
        PlayerPosition playerPosition = SaveLoadData.LoadPlayerPosition();

        if (SceneManager.GetActiveScene().name != playerPosition.sceneName)
        {
            SceneManager.LoadScene(playerPosition.sceneName);
        }

        player.transform.position = playerPosition.ToVector3();
        
    }

}
