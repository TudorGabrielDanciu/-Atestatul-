using UnityEngine;
using TMPro;

public class FadeFlickerText : MonoBehaviour
{
    public TextMeshProUGUI flickerText;
    public float fadeSpeed = 1f;
    private bool fadingOut = true;

    void Update()
    {
        Color color = flickerText.color;
        float alphaChange = fadeSpeed * Time.deltaTime;

        if (fadingOut)
        {
            color.a -= alphaChange;
            if (color.a <= 0f)
            {
                color.a = 0f;
                fadingOut = false;
            }
        }
        else
        {
            color.a += alphaChange;
            if (color.a >= 1f)
            {
                color.a = 1f;
                fadingOut = true;
            }
        }

        flickerText.color = color;
    }
}
