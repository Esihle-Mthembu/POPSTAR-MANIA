using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip mainMenuMusic;
    public AudioClip clickSound;
    public AudioClip lyricGameMusic;

    private AudioClip previousMusicClip;

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
        StopAllCoroutines();

        if (SettingsMenu.Instance != null)
        {
            SettingsMenu.Instance.RefreshAfterSceneLoad();
        }

        if (scene.name == "Main Menu")
        {
            PlayMainMenuMusic();
            return;
        }

        StopMusic();
    }

    public void StopMusic()
    {
        if (musicCoroutine != null)
        {
            StopCoroutine(musicCoroutine);
        }

        StartCoroutine(FadeOutMusic());
    }

    IEnumerator FadeOutMusic()
    {
        while (musicSource != null && musicSource.volume > 0.01f)
        {
            musicSource.volume -= Time.deltaTime;
            yield return null;
        }

        if (musicSource != null)
        {
            musicSource.Stop();
            musicSource.clip = null;
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

        while (musicSource != null && musicSource.volume > 0.01f)
        {
            musicSource.volume -= Time.deltaTime;
            yield return null;
        }

        if (musicSource == null) yield break;

        musicSource.Stop();
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
        // Prefer MusicManager's click if present and assigned
        if (MusicManager.Instance != null && MusicManager.Instance.clickSound != null)
        {
            Debug.Log("[AudioManager] Delegating PlayClick to MusicManager");
            MusicManager.Instance.PlayClick();
            return;
        }

        // If MusicManager exists but has no clip, fall back to AudioManager's clip
        if (MusicManager.Instance != null && MusicManager.Instance.clickSound == null)
        {
            Debug.Log("[AudioManager] MusicManager present but no clickSound; falling back to AudioManager clickSound");
        }

        if (sfxSource == null)
        {
            Debug.LogError("SFX Source is NULL (AudioManager)");
            return;
        }

        if (!sfxSource.enabled || !sfxSource.gameObject.activeInHierarchy)
        {
            Debug.LogWarning("SFX Source disabled or inactive (AudioManager)");
            return;
        }

        if (clickSound != null)
        {
            sfxSource.PlayOneShot(clickSound);
            Debug.Log("[AudioManager] Played clickSound on sfxSource");
        }
        else
        {
            Debug.LogWarning("No clickSound assigned in MusicManager or AudioManager");
        }
    }

    // Lyrics game music
    public void PlayLyricGameMusic()
    {
        previousMusicClip = musicSource != null ? musicSource.clip : null;
        PlayMusic(lyricGameMusic);
    }

    public void RestorePreviousMusic()
    {
        if (previousMusicClip != null)
        {
            PlayMusic(previousMusicClip);
        }
        else
        {
            PlayMainMenuMusic();
        }
    }
}