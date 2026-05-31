using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OpeningSceneController : MonoBehaviour
{
    [Header("Opening Scene")]
    public string nextSceneName = "Main Menu";

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip openingMusic;

    [Header("Fade Settings")]
    public float fadeInDuration = 2f;
    public float fadeOutDuration = 1.5f;

    private void Start()
    {
        if (audioSource == null)
        {
            Debug.LogWarning("No AudioSource assigned.");
            return;
        }

        if (openingMusic != null)
        {
            audioSource.clip = openingMusic;
            audioSource.loop = true;
            audioSource.volume = 0f;
            audioSource.Play();

            StartCoroutine(FadeIn());
        }
    }

    // ENTER BUTTON
    public void EnterGame()
    {
        StartCoroutine(FadeOutAndLoad());
    }

    // EXIT BUTTON
    public void ExitGame()
    {
        Debug.Log("Game is exiting");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    IEnumerator FadeIn()
    {
        float t = 0f;

        while (t < fadeInDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, 1f, t / fadeInDuration);
            yield return null;
        }

        audioSource.volume = 1f;
    }

    IEnumerator FadeOutAndLoad()
    {
        float startVolume = audioSource.volume;
        float t = 0f;

        while (t < fadeOutDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeOutDuration);
            yield return null;
        }

        audioSource.volume = 0f;

        SceneManager.LoadScene(nextSceneName);
    }
}
