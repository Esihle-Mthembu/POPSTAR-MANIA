using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance;

    private Vector3 originalPosition;
    private Coroutine shakeCoroutine;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    // Start Shake
    public void StartShake(float duration, float strength)
    {
        // Stop old shake first
        StopShake();

        shakeCoroutine = StartCoroutine(Shake(duration, strength));
    }

    // Stop Shake
    public void StopShake()
    {
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
        }

        transform.localPosition = originalPosition;
    }

    IEnumerator Shake(float duration, float strength)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-strength, strength);
            float y = Random.Range(-strength, strength);

            transform.localPosition = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}