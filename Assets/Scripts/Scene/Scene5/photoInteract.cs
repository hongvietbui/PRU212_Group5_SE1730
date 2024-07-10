using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotoInteraction : MonoBehaviour
{
	private bool isPlayerNear = false;

	void Update()
	{
		if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
		{
			SceneManager.LoadScene("Scene5_ExitClassRoom"); // Thay th? b?ng tên c?nh b?n mu?n t?i
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			isPlayerNear = true;
			// Tu? ch?n, hi?n th? l?i nh?c UI cho ng??i ch?i
			Debug.Log("Nh?n E ?? t??ng tác v?i ?nh");
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			isPlayerNear = false;
			// Tu? ch?n, ?n l?i nh?c UI
			Debug.Log("R?i kh?i khu v?c t??ng tác v?i ?nh");
		}
	}
}
