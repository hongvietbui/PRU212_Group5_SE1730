using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene5 : MonoBehaviour
{
	// Start is called before the first frame update
	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene("Scene5");
	}
}
