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
    public AudioClip lyricGameMusic;
    private AudioClip previousMusicClip;

    private bool allowSceneMusic = true;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (musicSource != null)
        {
            musicSource.enabled = true;
            musicSource.playOnAwake = false;
        }

        if (sfxSource != null)
        {
            sfxSource.enabled = true;
            sfxSource.playOnAwake = false;
        }
    }

    void Start()
    {
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
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
        if (!allowSceneMusic)
        {
            Debug.Log("Scene music blocked");
            return;
        }

        StopAllCoroutines();

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

    public void PlayClick()
    {
        if (clickSound == null || sfxSource == null) return;

        sfxSource.PlayOneShot(clickSound);
    }

    //Lyric game music
    public void PlayLyricGameMusic()
    {
        Debug.Log("Lyric music triggered");

        allowSceneMusic = false;

        previousMusicClip = musicSource.clip;
        PlayMusic(lyricGameMusic);
    }

    //Stops playing lyric game music and restores in-game music
    public void RestorePreviousMusic()
    {
        allowSceneMusic = true;

        if (previousMusicClip != null)
            PlayMusic(previousMusicClip);
        else
            PlayGameMusic();
    }

    //Music and sounds control
    private Coroutine musicCoroutine;

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogError("Music clip is NULL");
            return;
        }

        Debug.Log("Playing music: " + clip.name);

        if (musicSource == null)
        {
            Debug.LogError("MusicSource is NULL");
            return;
        }

        if (musicCoroutine != null)
            StopCoroutine(musicCoroutine);

        musicCoroutine = StartCoroutine(FadeMusic(clip));
    }

    IEnumerator FadeMusic(AudioClip newClip)
    {
        float targetVolume = 1f;

        // fade out
        while (musicSource.volume > 0.01f)
        {
            musicSource.volume -= Time.deltaTime;
            yield return null;
        }

        musicSource.clip = newClip;
        musicSource.volume = 0f;
        musicSource.Play();

        // fade in
        while (musicSource.volume < targetVolume)
        {
            musicSource.volume += Time.deltaTime;
            yield return null;
        }

        musicSource.volume = targetVolume;
    }
}