using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text dialogueText;
    public float typingSpeed = 0.05f;

    private string fullText;
    private string currentText = "";

        void Start()
        {
            StartCoroutine(ShowText());
        }

        public void StartTypewriterEffect(string text)
        {
            fullText = text;
            currentText = "";
            StartCoroutine(ShowText());
        }

        IEnumerator ShowText()
        {
            for (int i = 0; i < fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i + 1);
                dialogueText.text = currentText;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
}
