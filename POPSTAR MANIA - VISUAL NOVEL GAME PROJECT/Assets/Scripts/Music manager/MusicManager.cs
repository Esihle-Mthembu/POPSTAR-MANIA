using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static bool musicExists = false;

    public AudioSource musicSource;

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
        }
    }

    // play new music each time (you can expand this to support multiple tracks or crossfading if needed)
    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;

        // Don't restart the same track
        if (musicSource.clip == clip && musicSource.isPlaying) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    // stop music when needed (e.g., on game over or when switching to a non-gameplay scene)
    public void StopMusic()
    {
        musicSource.Stop();
    }
}