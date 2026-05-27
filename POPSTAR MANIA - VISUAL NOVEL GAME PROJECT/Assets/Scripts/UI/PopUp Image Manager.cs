using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpImageManager : MonoBehaviour
{
    public static PopUpImageManager Instance;

    [Header("References")]
    public CanvasGroup canvasGroup;
    public Image popupImage;

    [Header("Settings")]
    public float fadeSpeed = 2f;

    Coroutine currentRoutine;

    void Awake()
    {
        Instance = this;
    }

    public void ShowImage(Sprite sprite)
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine); 
        }

        currentRoutine = StartCoroutine(FadeIn(sprite));
    }

    public void HideImage()
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }

        currentRoutine = StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn(Sprite sprite)
    {
        popupImage.sprite = sprite;

        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        canvasGroup.alpha = 1;
    }

    IEnumerator FadeOut()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        canvasGroup.alpha = 0;
    }
}
