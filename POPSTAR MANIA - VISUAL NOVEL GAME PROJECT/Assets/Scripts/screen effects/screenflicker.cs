using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFlicker : MonoBehaviour
{
    public static ScreenFlicker Instance;

    [Header("Overlay Image")]
    public Image flickerImage;

  //ADD SOMETHING THAT STOPS THE MUSIC FROM CARRYING ON TO THE NEXT LINE
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
        StartCoroutine(FlickerEffect(duration));
    }

    IEnumerator FlickerEffect(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            // Random alpha flash
            Color color = flickerImage.color;
            color.a = Random.Range(0f, 0.5f);
            flickerImage.color = color;

            // Tiny wait for fast flicker
            yield return new WaitForSeconds(Random.Range(0.02f, 0.08f));

            timer += Time.deltaTime;
        }

        // Reset overlay to invisible
        Color reset = flickerImage.color;
        reset.a = 0f;
        flickerImage.color = reset;
    }
}