using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    private static bool musicExists = false;

    // Primary persistent music source (used for BGM)
    public AudioSource musicSource;

    // Overlay source for per-line background music that can be started/stopped independently
    public AudioSource overlaySource;

    // SFX for UI / clicks (optional)
    public AudioSource sfxSource;
    public AudioClip clickSound;

    // Fade durations 
    public float persistentFadeDuration = 0.6f;
    public float overlayFadeDuration = 0.25f;

    private Coroutine persistentCoroutine;
    private Coroutine overlayCoroutine;

    private AudioClip previousMusicClip;

    void Awake()
    {
        // one music manager across the scenes 
        if (!musicExists)
        {
            DontDestroyOnLoad(gameObject);
            musicExists = true;
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        if (musicSource == null)
        {
            musicSource = gameObject.GetComponent<AudioSource>();
            if (musicSource == null)
            {
                musicSource = gameObject.AddComponent<AudioSource>();
                musicSource.playOnAwake = false;
                musicSource.loop = true;
                Debug.Log("[MusicManager] created fallback musicSource AudioSource");
            }
        }

        // Ensure overlay source exists
        if (overlaySource == null)
        {
            // If another AudioSource exists besides musicSource, use it
            var sources = GetComponents<AudioSource>();
            foreach (var s in sources)
            {
                if (s != musicSource)
                {
                    overlaySource = s;
                    break;
                }
            }

            if (overlaySource == null)
            {
                overlaySource = gameObject.AddComponent<AudioSource>();
                overlaySource.playOnAwake = false;
                overlaySource.loop = true;
                Debug.Log("[MusicManager] created overlaySource AudioSource");
            }
        }

        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.playOnAwake = false;
            sfxSource.loop = false;
            sfxSource.spatialBlend = 0f;

            Debug.Log("[MusicManager] created dedicated sfxSource");
        }

        // Normalize volumes
        if (musicSource != null) musicSource.volume = 1f;
        if (overlaySource != null) overlaySource.volume = 1f;
        if (sfxSource != null) sfxSource.volume = 1f;
    }

    // Backwards-compatible: treat as persistent BGM
    public void PlayMusic(AudioClip clip)
    {
        PlayPersistent(clip);
    }

    // Play or switch persistent BGM (persists across lines) with fade
    public void PlayPersistent(AudioClip clip)
    {
        if (clip == null) return;

        if (musicSource == null)
        {
            Debug.LogWarning("MusicManager.PlayPersistent: no AudioSource assigned. Cannot play clip.");
            return;
        }

        // If already playing the requested clip, nothing to do
        if (musicSource.isPlaying && musicSource.clip == clip)
            return;

        if (persistentCoroutine != null)
            StopCoroutine(persistentCoroutine);

        persistentCoroutine = StartCoroutine(FadePersistentTo(clip, persistentFadeDuration));
    }

    // Fade to the new persistent clip
    private IEnumerator FadePersistentTo(AudioClip newClip, float duration)
    {
        if (musicSource == null)
        {
            persistentCoroutine = null;
            yield break;
        }

        if (duration <= 0f)
        {
            musicSource.clip = newClip;
            musicSource.loop = true;
            musicSource.volume = 1f;
            if (!musicSource.isPlaying) musicSource.Play();
            persistentCoroutine = null;
            yield break;
        }

        // If currently not playing, just fade IN the new clip
        if (!musicSource.isPlaying)
        {
            musicSource.clip = newClip;
            musicSource.loop = true;
            musicSource.volume = 0f;
            musicSource.Play();

            float t = 0f;
            while (t < duration)
            {
                t += Time.deltaTime;
                musicSource.volume = Mathf.Clamp01(t / duration);
                yield return null;
            }

            musicSource.volume = 1f;
            persistentCoroutine = null;
            yield break;
        }

        // If playing a different clip, fade OUT, swap clip, then fade IN
        float half = duration * 0.5f;
        float elapsed = 0f;
        float startVol = musicSource.volume;

        // Fade out
        while (elapsed < half)
        {
            elapsed += Time.deltaTime;
            float f = Mathf.Clamp01(elapsed / half);
            musicSource.volume = Mathf.Lerp(startVol, 0f, f);
            yield return null;
        }

        musicSource.volume = 0f;
        musicSource.Stop();

        // Swap to new clip and fade in
        musicSource.clip = newClip;
        musicSource.loop = true;
        musicSource.Play();

        elapsed = 0f;
        while (elapsed < half)
        {
            elapsed += Time.deltaTime;
            float f = Mathf.Clamp01(elapsed / half);
            musicSource.volume = Mathf.Lerp(0f, 1f, f);
            yield return null;
        }

        musicSource.volume = 1f;
        persistentCoroutine = null;
    }

    // Play temporary/line background music on overlay source with fade
    public void PlayOverlay(AudioClip clip)
    {
        if (clip == null)
        {
            StopOverlay();
            return;
        }

        if (overlaySource == null)
        {
            Debug.LogWarning("MusicManager.PlayOverlay: overlaySource is NULL, creating new one");
            overlaySource = gameObject.AddComponent<AudioSource>();
            overlaySource.playOnAwake = false;
            overlaySource.loop = true;
        }

        // If already playing the requested overlay, nothing to do
        if (overlaySource.isPlaying && overlaySource.clip == clip && overlaySource.volume >= 0.99f)
            return;

        if (overlayCoroutine != null)
            StopCoroutine(overlayCoroutine);

        overlayCoroutine = StartCoroutine(FadeOverlayIn(clip, overlayFadeDuration));
    }

    private IEnumerator FadeOverlayIn(AudioClip clip, float duration)
    {
        if (overlaySource == null)
        {
            overlayCoroutine = null;
            yield break;
        }

        if (duration <= 0f)
        {
            overlaySource.clip = clip;
            overlaySource.loop = true;
            overlaySource.volume = 1f;
            overlaySource.Play();
            overlayCoroutine = null;
            yield break;
        }

        float elapsed = 0f;

        // If currently playing something else, fade it out quickly (optional)
        if (overlaySource.isPlaying && overlaySource.clip != clip)
        {
            float start = overlaySource.volume;
            while (elapsed < duration * 0.5f)
            {
                elapsed += Time.deltaTime;
                overlaySource.volume = Mathf.Lerp(start, 0f, Mathf.Clamp01(elapsed / (duration * 0.5f)));
                yield return null;
            }
            overlaySource.Stop();
        }

        overlaySource.clip = clip;
        overlaySource.loop = true;
        overlaySource.volume = 0f;
        overlaySource.Play();

        elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            overlaySource.volume = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        overlaySource.volume = 1f;
        overlayCoroutine = null;
    }

    // Stop the overlay (per-line) music with fade
    public void StopOverlay()
    {
        if (overlaySource == null) return;

        if (overlayCoroutine != null)
            StopCoroutine(overlayCoroutine);

        overlayCoroutine = StartCoroutine(FadeOverlayOut(overlayFadeDuration));
    }

    private IEnumerator FadeOverlayOut(float duration)
    {
        if (overlaySource == null)
        {
            overlayCoroutine = null;
            yield break;
        }

        if (!overlaySource.isPlaying)
        {
            overlaySource.clip = null;
            overlayCoroutine = null;
            yield break;
        }

        if (duration <= 0f)
        {
            overlaySource.Stop();
            overlaySource.clip = null;
            overlayCoroutine = null;
            yield break;
        }

        float elapsed = 0f;
        float startVol = overlaySource.volume;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            overlaySource.volume = Mathf.Lerp(startVol, 0f, t);
            yield return null;
        }

        overlaySource.Stop();
        overlaySource.clip = null;
        overlaySource.volume = 1f; // reset default
        overlayCoroutine = null;
    }

    // Stop all music (persistent + overlay) with fades
    public void StopMusic()
    {
        // fade out overlay quickly
        if (overlayCoroutine != null)
            StopCoroutine(overlayCoroutine);
        overlayCoroutine = StartCoroutine(FadeOverlayOut(overlayFadeDuration));

        // fade out persistent
        if (persistentCoroutine != null)
            StopCoroutine(persistentCoroutine);
        persistentCoroutine = StartCoroutine(FadePersistentOutAndClear(persistentFadeDuration));
    }

    private IEnumerator FadePersistentOutAndClear(float duration)
    {
        if (musicSource == null)
        {
            persistentCoroutine = null;
            yield break;
        }

        if (!musicSource.isPlaying)
        {
            musicSource.clip = null;
            persistentCoroutine = null;
            yield break;
        }

        if (duration <= 0f)
        {
            musicSource.Stop();
            musicSource.clip = null;
            persistentCoroutine = null;
            yield break;
        }

        float elapsed = 0f;
        float startVol = musicSource.volume;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            musicSource.volume = Mathf.Lerp(startVol, 0f, t);
            yield return null;
        }

        musicSource.Stop();
        musicSource.clip = null;
        musicSource.volume = 1f;
        persistentCoroutine = null;
    }

    // Store current music and play a lyric-game clip (used for temporary switches)
    public void PlayLyricGameMusic(AudioClip lyricClip)
    {
        if (musicSource != null)
            previousMusicClip = musicSource.clip;
        PlayPersistent(lyricClip);
    }

    public void RestorePreviousMusic()
    {
        if (previousMusicClip != null)
            PlayPersistent(previousMusicClip);
        else
            StopMusic();
    }

    // UI click SFX
    public void PlayClick()
    {
        if (clickSound == null)
        {
            Debug.LogWarning("[MusicManager] PlayClick called but clickSound is null");
            return;
        }

        // Ensure a usable sfxSource exists
        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.playOnAwake = false;
            sfxSource.spatialBlend = 0f;
            sfxSource.loop = false;
        }

        if (!sfxSource.enabled || !sfxSource.gameObject.activeInHierarchy)
        {
            Debug.LogWarning("[MusicManager] sfxSource disabled or inactive");
            return;
        }

        Debug.Log("[MusicManager] Playing clickSound: " + clickSound.name);
        sfxSource.PlayOneShot(clickSound);
    }
}