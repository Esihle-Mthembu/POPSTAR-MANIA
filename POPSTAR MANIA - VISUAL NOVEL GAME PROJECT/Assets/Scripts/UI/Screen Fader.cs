using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public System.Action OnFadeComplete;
    public bool isTransitioning = false;
    public IEnumerator FadeIn()
    {
        float t = 0;
        Color color = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0;
        fadeImage.color = color;

        fadeImage.raycastTarget = false; //allows clicks again

        isTransitioning = false;  

        OnFadeComplete?.Invoke();
    }

    public IEnumerator FadeOut()
    {
        if (isTransitioning) yield break;
        isTransitioning = true;

        fadeImage.raycastTarget = true;

        float t = 0;
        Color color = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1;
        fadeImage.color = color;
    }
}
