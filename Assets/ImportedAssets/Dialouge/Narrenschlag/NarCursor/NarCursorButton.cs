using narrenschlag.dialoguez;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NarCursorButton : MonoBehaviour
{
    public bool debug;
    NarCursor cursor;

    RectTransform rt;
    RectTransform c;
    Button b;

    Vector2 size;

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        cursor = NarCursor.singleton;

        rt = GetComponent<RectTransform>();
        b = GetComponent<Button>();
        c = cursor.cursor;

        size = rt.rect.size;
    }

    void Update()
    {
        if (!c || !b)
            return;

        bool inp = Input.GetMouseButtonDown(1);
        bool contains = rt.Contains(size, c.transform.position, debug);

        if (inp && b.onClick != null)
        {
            if (contains && b.interactable && b.onClick != null)
            {
                b.onClick.Invoke();

                // Additional logic to handle when the last sentence is clicked
                DialogueZStyle_Vegas dialogueStyle = FindObjectOfType<DialogueZStyle_Vegas>();
                if (dialogueStyle != null)
                {
                    dialogueStyle.OnLastSentence();
                }
            }
        }
    }
}
