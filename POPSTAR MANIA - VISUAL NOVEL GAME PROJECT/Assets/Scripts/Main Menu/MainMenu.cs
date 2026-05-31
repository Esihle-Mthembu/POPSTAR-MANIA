using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class MainMenu : MonoBehaviour
{
    public AudioSource menuMusicSource;
    public AudioClip menuMusic;
    public float fadeDuration = 1f;

    // stop music if returning to main menu from in-game
    void Start()
    {
        // Stop in-game music
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.StopMusic();
        }

        // Start menu music
        if (menuMusicSource != null && menuMusic != null)
        {
            menuMusicSource.clip = menuMusic;
            menuMusicSource.volume = 0f;
            menuMusicSource.loop = true;
            menuMusicSource.Play();

            StartCoroutine(FadeInMenuMusic());
        }
    }

    // Continue button
    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("SceneName"))
        {
            string sceneName = PlayerPrefs.GetString("SceneName");
            Debug.Log("Loading scene:" + sceneName);

            // Play click (prefer AudioManager -> MusicManager delegation)
           // if (AudioManager.Instance != null)
            {
              //  AudioManager.Instance.PlayClick();
                StartCoroutine(LoadSceneDelayed(sceneName, 0.1f)); // smsall delay to start sound
            }
          //  else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            Debug.Log("No saved game exists");
        }
    }

    private IEnumerator LoadSceneDelayed(string sceneName, float delaySeconds)
    {
        if (menuMusicSource != null)
        {
            yield return StartCoroutine(FadeOutMenuMusic());
        }

        yield return new WaitForSeconds(delaySeconds);

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeInMenuMusic()
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            menuMusicSource.volume = Mathf.Lerp(0f, 1f, time / fadeDuration);
            yield return null;
        }

        menuMusicSource.volume = 1f;
    }

    IEnumerator FadeOutMenuMusic()
    {
        float startVolume = menuMusicSource.volume;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            menuMusicSource.volume = Mathf.Lerp(startVolume, 0f, time / fadeDuration);
            yield return null;
        }

        menuMusicSource.volume = 0f;
        menuMusicSource.Stop();
    }

    // New Game button
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("StartDialogue", "Prologue");
        SceneManager.LoadScene("In-Game UI scene");
    }

    // Settings button
    public void Settings()
    {
        if (SettingsMenu.Instance != null)
        {
            SettingsMenu.Instance.OpenSettings();
        }
        else
        {
            Debug.LogError("SettingsMenu.Instance is null, not initialized yet");
        }
    }

    // Exit button
    public void QuitGame()
    {
        Application.Quit();
    }
}