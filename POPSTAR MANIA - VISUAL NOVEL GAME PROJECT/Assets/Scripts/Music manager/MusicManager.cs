using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static bool musicExists = false;

    // Primary persistent music source (used for BGM)
    public AudioSource musicSource;

    // Overlay source for per-line background music that can be started/stopped independently
    public AudioSource overlaySource;

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
            }
        }

        // Normalize volumes
        if (musicSource != null) musicSource.volume = 1f;
        if (overlaySource != null) overlaySource.volume = 1f;
    }

    // Backwards-compatible: treat as persistent BGM
    public void PlayMusic(AudioClip clip)
    {
        PlayPersistent(clip);
    }

    // Play or switch persistent BGM (persists across lines)
    public void PlayPersistent(AudioClip clip)
    {
        if (clip == null) return;

        // runtime fallback: try AudioManager if musicSource missing
        if (musicSource == null)
        {
            var am = AudioManager.Instance;
            if (am != null) musicSource = am.musicSource;
        }

        if (musicSource == null)
        {
            Debug.LogWarning("MusicManager.PlayPersistent: no AudioSource assigned. Cannot play clip.");
            return;
        }

        if (musicSource.clip == clip && musicSource.isPlaying) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Play temporary/line background music on overlay source
    public void PlayOverlay(AudioClip clip)
    {
        if (clip == null)
        {
            StopOverlay();
            return;
        }

        if (overlaySource == null)
        {
            overlaySource = gameObject.AddComponent<AudioSource>();
            overlaySource.playOnAwake = false;
            overlaySource.loop = true;
        }

        overlaySource.clip = clip;
        overlaySource.loop = true;
        overlaySource.Play();
    }

    // Stop the overlay (per-line) music
    public void StopOverlay()
    {
        if (overlaySource == null) return;
        if (overlaySource.isPlaying) overlaySource.Stop();
        overlaySource.clip = null;
    }

    // Stop all music (persistent + overlay)
    public void StopMusic()
    {
        if (overlaySource != null)
        {
            if (overlaySource.isPlaying) overlaySource.Stop();
            overlaySource.clip = null;
        }

        if (musicSource != null)
        {
            if (musicSource.isPlaying) musicSource.Stop();
            musicSource.clip = null;
        }
    }
}