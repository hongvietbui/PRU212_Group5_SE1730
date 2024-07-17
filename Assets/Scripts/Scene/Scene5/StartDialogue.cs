using narrenschlag.dialoguez;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StartDialogue : MonoBehaviour
{
	public DialogueZ dialogueManager;
	public UnityEvent OnGameStart;

	private string dialogueKey = "HasShownDialogue"; // Khóa lưu trữ trạng thái

	// Start is called before the first frame update
	void Start()
	{
		if (!PlayerPrefs.HasKey(dialogueKey) || PlayerPrefs.GetInt(dialogueKey) == 0)
		{
			OnGameStart.Invoke();
			PlayerPrefs.SetInt(dialogueKey, 1); // Lưu trạng thái đã hiển thị
			PlayerPrefs.Save();
		}
	}

	private void OnApplicationQuit()
	{
		PlayerPrefs.DeleteKey(dialogueKey);
	}
}
