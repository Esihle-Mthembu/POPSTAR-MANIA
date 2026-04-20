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

    private static bool created = false;
    private Coroutine musicCoroutine;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void CreateAudioManager()
    {
        if (created) return;

        GameObject obj = Resources.Load<GameObject>("Audio Manager");

        if (obj != null)
        {
            Instantiate(obj);
            created = true;
        }
        else
        {
            Debug.LogError("AudioManager prefab missing in Resources folder!");
        }
    }


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
            musicSource.gameObject.SetActive(true);
            musicSource.playOnAwake = false;
        }

        if (sfxSource != null)
        {
            sfxSource.enabled = true;
            sfxSource.gameObject.SetActive(true);
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

    void Update()
    {
        if (sfxSource != null && !sfxSource.enabled)
        {
            Debug.LogError("SFX DISABLED THIS FRAME → something is overriding it");
        }
    }

    //Music
    public void PlayMainMenuMusic() => PlayMusic(mainMenuMusic);
    public void PlayGameMusic() => PlayMusic(gameMusic);

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;

        if (musicCoroutine != null)
        {
            StopCoroutine(musicCoroutine);
        }

        musicCoroutine = StartCoroutine(FadeMusic(clip));
    }

    IEnumerator FadeMusic(AudioClip newClip)
    {
        float targetVolume = 1f;

        while (musicSource.volume > 0.01f)
        {
            musicSource.volume -= Time.deltaTime;
            yield return null;
        }

        musicSource.clip = newClip;
        musicSource.volume = 0f;
        musicSource.Play();

        while (musicSource.volume < targetVolume)
        {
            musicSource.volume += Time.deltaTime;
            yield return null;
        }

        musicSource.volume = targetVolume;
    }

    // sfx
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayClick()
    {
        if (clickSound == null || sfxSource == null) return;

        // FORCE FIX EVERYTHING
        sfxSource.gameObject.SetActive(true);
        sfxSource.enabled = true;

        if (!sfxSource.isActiveAndEnabled)
        {
            Debug.LogError("SFX STILL DISABLED AFTER FIX → something is breaking it");
            return;
        }

        sfxSource.PlayOneShot(clickSound);
    }

    // Lyrics game music
    public void PlayLyricGameMusic()
    {
        allowSceneMusic = false;

        previousMusicClip = musicSource.clip;
        PlayMusic(lyricGameMusic);
    }

    public void RestorePreviousMusic()
    {
        allowSceneMusic = true;

        if (previousMusicClip != null)
        {
            PlayMusic(previousMusicClip);
        }
        else
        {
            PlayGameMusic();
        }
    }
}