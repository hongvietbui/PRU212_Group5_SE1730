using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class TextChangeColorController : MonoBehaviour
{
    public TMP_Text text;
    public Color lightBackgroundColor = Color.black;
    public Color darkBackgroundColor = Color.white;
    public float colorChangeThreshold = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
    //    Color backgroundColor = SampleBackgroundColor(screenPos);

    //    float brightness = backgroundColor.r * 0.2126f + backgroundColor.g * 0.7152f + backgroundColor.b * 0.0722f;
    //    if (brightness > colorChangeThreshold)
    //    {
    //        text.color = lightBackgroundColor;
    //    }
    //    else
    //    {
    //        text.color = darkBackgroundColor;
    //    }
    //}

    private void LateUpdate()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log("Screen Pos: " + screenPos);

        screenPos.x = Mathf.Clamp(screenPos.x, 0, Screen.width - 1);
        screenPos.y = Mathf.Clamp(screenPos.y, 0, Screen.height - 1);

        Color backgroundColor = SampleBackgroundColor(screenPos);

        float brightness = backgroundColor.r * 0.2126f + backgroundColor.g * 0.7152f + backgroundColor.b * 0.0722f;

        if(brightness > colorChangeThreshold)
        {
            text.color = lightBackgroundColor;
        }
        else
        {
            text.color = darkBackgroundColor;
        }
    }

    private Color SampleBackgroundColor(Vector2 screenPos)
    {
        RenderTexture rt = new RenderTexture(1, 1, 32);
        Camera.main.targetTexture = rt;
        Camera.main.Render();
        RenderTexture.active = rt;

        Texture2D tex = new Texture2D(1, 1, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(screenPos.x, screenPos.y, 1, 1), 0, 0);
        tex.Apply();

        Camera.main.targetTexture = null;
        RenderTexture.active = null;

        Color color = tex.GetPixel(0, 0);
        Destroy(rt);
        Destroy(tex);

        return color;
    }
}
