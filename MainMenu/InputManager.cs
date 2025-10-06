using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeToBlackOnKey : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1f;
    public string nextSceneName = "Game";


    private bool isFading = false;

    void Update()
    {
        if (!isFading && Input.anyKeyDown)
        {
            StartCoroutine(FadeAndLoad());
        }
    }

    System.Collections.IEnumerator FadeAndLoad()
    {
        isFading = true;
        float alpha = 0f;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            Color newColor = fadeImage.color;
            newColor.a = Mathf.Clamp01(alpha);
            fadeImage.color = newColor;
            yield return null;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}