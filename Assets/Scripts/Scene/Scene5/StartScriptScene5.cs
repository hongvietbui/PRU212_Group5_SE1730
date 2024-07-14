using UnityEngine;
using UnityEngine.UI; // Nếu bạn sử dụng Text UI
using TMPro; // Nếu bạn sử dụng TextMeshPro

public class StartScriptScene5 : MonoBehaviour
{
    public Text dialogueText; // Nếu bạn sử dụng Text UI
    // public TextMeshProUGUI dialogueText; // Nếu bạn sử dụng TextMeshPro
    public string[] dialogueLines;
    private int currentLineIndex = 0;

    void Start()
    {
        if (dialogueLines.Length > 0)
        {
            ShowNextDialogue();
        }
    }

    void ShowNextDialogue()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
            currentLineIndex++;
        }
        else
        {
            // Kết thúc đoạn hội thoại
            dialogueText.text = "";
        }
    }

    // Gọi hàm này nếu bạn muốn điều khiển đoạn hội thoại bằng cách khác
    public void NextDialogue()
    {
        ShowNextDialogue();
    }
}
