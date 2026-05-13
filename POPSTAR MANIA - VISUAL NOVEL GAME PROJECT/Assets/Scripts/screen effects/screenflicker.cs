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
            color.a = Random.Range(0f, 0.5f);
            flickerImage.color = color;

            yield return new WaitForSeconds(Random.Range(0.02f, 0.08f));

            timer += Time.deltaTime;
        }

        // Reset overlay
        Color reset = flickerImage.color;
        reset.a = 0f;
        flickerImage.color = reset;
    }
}