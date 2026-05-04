using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    private static bool musicExists = false;

    // Primary (exposed) audio source reference. After crossfades this will point to the active source.
    public AudioSource musicSource;

    // Secondary audio source used for crossfading
    private AudioSource secondarySource;

    // Default crossfade duration (seconds)
    public float defaultCrossfadeDuration = 0.5f;

    private Coroutine crossfadeCoroutine;

    void Awake()
    {
        // one music manager across the scenes 
        if (!musicExists)
        {
            DontDestroyOnLoad(gameObject);
            musicExists = true;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Ensure primary audio source exists on the GameObject
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.playOnAwake = false;
            musicSource.loop = true;
        }

        // Create secondary audio source for crossfading
        // If one already exists (e.g., added in editor), don't create duplicate.
        var sources = GetComponents<AudioSource>();
        if (sources.Length < 2)
        {
            secondarySource = gameObject.AddComponent<AudioSource>();
            secondarySource.playOnAwake = false;
            secondarySource.loop = true;
        }
        else
        {
            // Find an AudioSource that isn't the public musicSource
            secondarySource = null;
            foreach (var s in sources)
            {
                if (s != musicSource)
                {
                    secondarySource = s;
                    break;
                }
            }

            if (secondarySource == null)
            {
                secondarySource = gameObject.AddComponent<AudioSource>();
                secondarySource.playOnAwake = false;
                secondarySource.loop = true;
            }
        }

        // Normalize volumes
        if (musicSource != null) musicSource.volume = 1f;
        if (secondarySource != null) secondarySource.volume = 0f;
    }

    // play new music with default crossfade
    public void PlayMusic(AudioClip clip)
    {
        PlayMusic(clip, defaultCrossfadeDuration);
    }

    // play new music with crossfade (duration seconds)
    public void PlayMusic(AudioClip clip, float crossfadeDuration)
    {
        if (clip == null) return;

        // If currently playing same clip, do nothing
        if (musicSource != null && musicSource.isPlaying && musicSource.clip == clip) return;

        // Start crossfade coroutine
        if (crossfadeCoroutine != null)
        {
            StopCoroutine(crossfadeCoroutine);
            crossfadeCoroutine = null;
        }

        crossfadeCoroutine = StartCoroutine(CrossfadeTo(clip, Mathf.Max(0f, crossfadeDuration)));
    }

    // stop music with default fade-out
    public void StopMusic()
    {
        StopMusic(defaultCrossfadeDuration);
    }

    // stop music with fade-out (duration seconds)
    public void StopMusic(float fadeDuration)
    {
        if (musicSource == null) return;

        if (crossfadeCoroutine != null)
        {
            StopCoroutine(crossfadeCoroutine);
            crossfadeCoroutine = null;
        }

        if (fadeDuration <= 0f)
        {
            musicSource.Stop();
            musicSource.clip = null;
            if (secondarySource != null)
            {
                secondarySource.Stop();
                secondarySource.clip = null;
            }
            return;
        }

        crossfadeCoroutine = StartCoroutine(FadeOutAndStop(fadeDuration));
    }

    private IEnumerator CrossfadeTo(AudioClip newClip, float duration)
    {
        // Prepare secondary source
        if (secondarySource == null)
        {
            secondarySource = gameObject.AddComponent<AudioSource>();
            secondarySource.playOnAwake = false;
            secondarySource.loop = true;
            secondarySource.volume = 0f;
        }

        secondarySource.clip = newClip;
        secondarySource.loop = true;
        secondarySource.volume = 0f;
        secondarySource.Play();

        float elapsed = 0f;
        float startVolumePrimary = (musicSource != null) ? musicSource.volume : 0f;
        float startVolumeSecondary = secondarySource.volume;

        // If duration is zero, instantly swap
        if (duration <= 0f)
        {
            if (musicSource != null)
            {
                musicSource.Stop();
                musicSource.clip = null;
            }

            secondarySource.volume = 1f;

            // Swap references so musicSource points to active source
            SwapPrimarySecondary();
            crossfadeCoroutine = null;
            yield break;
        }

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            if (musicSource != null) musicSource.volume = Mathf.Lerp(startVolumePrimary, 0f, t);
            secondarySource.volume = Mathf.Lerp(startVolumeSecondary, 1f, t);

            yield return null;
        }

        // Ensure final volumes
        if (musicSource != null) musicSource.volume = 0f;
        secondarySource.volume = 1f;

        // Stop old primary and clear its clip
        if (musicSource != null)
        {
            musicSource.Stop();
            musicSource.clip = null;
        }

        // Swap references so musicSource points to active source
        SwapPrimarySecondary();

        crossfadeCoroutine = null;
    }

    private IEnumerator FadeOutAndStop(float duration)
    {
        if (musicSource == null)
        {
            crossfadeCoroutine = null;
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
        musicSource.volume = 1f; // reset to default in case of future use

        // Ensure secondary is stopped/cleared too
        if (secondarySource != null && secondarySource.isPlaying)
        {
            secondarySource.Stop();
            secondarySource.clip = null;
            secondarySource.volume = 0f;
        }

        crossfadeCoroutine = null;
    }

    // Swap references so public musicSource becomes the active playing source
    private void SwapPrimarySecondary()
    {
        // Swap fields
        var temp = musicSource;
        musicSource = secondarySource;
        secondarySource = temp;
    }
}