using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance;

    private Vector3 originalPosition;

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

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void StartShake(float duration, float strength)
    {
        StartCoroutine(Shake(duration, strength));
    }

    IEnumerator Shake(float duration, float strength)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * strength;
            randomOffset.z = 0;

            transform.position = originalPosition + randomOffset;

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
    }

}