using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class ChangeTextService : MonoBehaviour
{
    private TMP_Text tmpText;
    // Start is called before the first frame update
    void Awake()
    {
        tmpText = GetComponent<TMP_Text>();
        if (tmpText == null)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeTextContent(string content)
    {
        //if (!tmpText.gameObject.active) {
        //    tmpText.SetText(content);
        //    tmpText.ForceMeshUpdate();
        //    tmpText.gameObject.active = true;
        //}
        if (tmpText != null)
        {
            tmpText.SetText(content);
            tmpText.ForceMeshUpdate();
        }
    }

    //public void ChangeTextContent(string content)
    //{
    //    StartCoroutine(UpdateTextAfterDelay(content));
    //}

    //private IEnumerator UpdateTextAfterDelay(string content)
    //{
    //    yield new WaitForSeconds(0.01f);
    //    if (tmpText != null)
    //    {
    //        tmpText.text = content;
    //        tmpText.ForceMeshUpdate(true);
    //    }
    //}


    public void ChangeFont(TMP_FontAsset font)
    {
        if (tmpText != null)
        {
            tmpText.font = font;
        }
    }

    //public void ActiveTMP() {
    //    tmpText.gameObject.SetActive(true);
    //}
}
