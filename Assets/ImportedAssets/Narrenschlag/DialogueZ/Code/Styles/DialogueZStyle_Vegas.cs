using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace narrenschlag.dialoguez
{
    public class DialogueZStyle_Vegas : DialogueZStyle
    {
    public Text title;
        public GameObject interactable_background;
        public override void DrawMessage(DialogueZElement e)
        {
            title.text = e.title;
            base.DrawMessage(e);
        }

        public override void SetParts_Message(bool b)
        {
            message.transform.parent.gameObject.SetActive(b);

            base.SetParts_Message(b);
        }
        public override void SetParts_Choice(bool b)
        {
            froot.parent.gameObject.SetActive(b);

            base.SetParts_Choice(b);
        }
        public void OnLastSentence()
        {
            // Assuming interactable_background is the GameObject you want to deactivate
            if (interactable_background != null)
            {
                interactable_background.SetActive(false);
            }
            else
            {
                Debug.LogWarning("interactable_background is not assigned.");
                // You may want to add fallback logic here or handle this case based on your specific requirements
            }
        }
    }
}