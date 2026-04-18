using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip mainMenuMusic;
    public AudioClip gameMusic;
    public AudioClip clickSound;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main Menu")
        {
            PlayMainMenuMusic();
        }
        else
        {
            PlayGameMusic();
        }
    }

    //Music
    void Start()
    {
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    public void PlayMainMenuMusic()
    {
        PlayMusic(mainMenuMusic);

        Debug.Log("Playing Main Menu Music: " + mainMenuMusic);
    }

    public void PlayGameMusic()
    {
        PlayMusic(gameMusic);
    }

    //SFX
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    //Music and sounds control
    private Coroutine musicCoroutine;

    public void PlayMusic(AudioClip clip)
    {
        if (musicCoroutine != null)
            StopCoroutine(musicCoroutine);

        musicCoroutine = StartCoroutine(FadeMusic(clip));
    }

    IEnumerator FadeMusic(AudioClip newClip)
    {
        float startVolume = musicSource.volume;

        // fade out
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0, t);
            yield return null;
        }

        musicSource.clip = newClip;
        musicSource.Play();

        // fade in
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            musicSource.volume = Mathf.Lerp(0, startVolume, t);
            yield return null;
        }
    }
}