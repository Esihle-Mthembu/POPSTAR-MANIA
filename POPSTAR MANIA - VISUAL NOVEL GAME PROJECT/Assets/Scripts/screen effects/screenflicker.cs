using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFlicker : MonoBehaviour
{
    public static ScreenFlicker Instance;

    [Header("Overlay Image")]
    public Image flickerImage;

    private Coroutine flickerCoroutine;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartFlicker(float duration)
    {
        // Stop old flicker first
        if (flickerCoroutine != null)
        {
            StopCoroutine(flickerCoroutine);
        }

        flickerCoroutine = StartCoroutine(FlickerEffect(duration));
    }

    public void StopFlicker()
    {
        if (flickerCoroutine != null)
        {
            StopCoroutine(flickerCoroutine);
        }

        // Reset alpha
        Color reset = flickerImage.color;
        reset.a = 0f;
        flickerImage.color = reset;
    }

    IEnumerator FlickerEffect(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            Color color = flickerImage.color;

            color.a = Random.Range(0f, 0.6f);

            flickerImage.color = color;

            flickerImage.rectTransform.anchoredPosition =
                new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));

            yield return new WaitForSeconds(0.02f);

            timer += Time.deltaTime;
        }

        flickerImage.rectTransform.anchoredPosition = Vector2.zero;

        Color reset = flickerImage.color;
        reset.a = 0f;
        flickerImage.color = reset;
    }
}