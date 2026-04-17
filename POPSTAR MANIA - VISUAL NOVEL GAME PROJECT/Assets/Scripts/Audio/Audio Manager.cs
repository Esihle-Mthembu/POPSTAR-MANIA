using UnityEngine;
using System.Collections;

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

    //Music
    void Start()
    {
        PlayMainMenuMusic();
    }

    public void PlayMainMenuMusic()
    {
        PlayMusic(mainMenuMusic);
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
    public void PlayMusic(AudioClip clip)
    {
        StartCoroutine(FadeMusic(clip));
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