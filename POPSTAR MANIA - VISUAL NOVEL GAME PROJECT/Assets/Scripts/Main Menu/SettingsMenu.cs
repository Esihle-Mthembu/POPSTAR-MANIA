using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu Instance;

    public GameObject settingsPanel;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private AudioManager audioManager;

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

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();

        if (audioManager == null)
        {
            Debug.LogError("Audio Manager not found in scene");
            return;
        }

        LoadSettings();
    }

    public void ToggleSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void SetMasterVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        audioManager.musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        audioManager.sfxSource.volume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void LoadSettings()
    {
        Debug.Log("AudioManager = " + audioManager);

        float master = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float music = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 1f);

        AudioListener.volume = master;

        if (audioManager != null)
        {
            if (audioManager.musicSource != null)
                audioManager.musicSource.volume = music;

            if (audioManager.musicSource != null) 
                audioManager.sfxSource.volume = sfx;
        }

        masterSlider.value = master;
        musicSlider.value = music;
        sfxSlider.value = sfx;
    }
}