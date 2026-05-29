using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu Instance;

    [Header ("UI")]
    public GameObject settingsPanel;

    [Header ("Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider typingSpeedSlider;

    [Header ("Audio")]
    public AudioMixer audioMixer;

    [Header ("Dialogue")]
    public DialogueManager dialogueManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        LoadSettings();
    }

    void LoadSettings()
    {
        //Load Audio
        float master = PlayerPrefs.GetFloat("MasterVol", 0.75f);
        float music = PlayerPrefs.GetFloat("MusicVol", 0.75f);
        float sfx = PlayerPrefs.GetFloat("SFXVol", 0.75f);
        float speed = PlayerPrefs.GetFloat("TypingSpeed", 0.75f);

        // Update Sliders
        masterSlider.value = master;
        musicSlider.value = music;
        sfxSlider.value = sfx;
        typingSpeedSlider.value = speed;

        // Apply to Mixer/Systems
        SetMasterVolume(master);
        SetMusicVolume(music);
        SetSFXVolume(sfx);
        ApplyTypingSpeed(speed);
    }

    //Audio
    public void SetMasterVolume(float value)
    {
        SetMixerVolume("Master", value);
        PlayerPrefs.SetFloat("MasterVol", value);
    }

    public void SetMusicVolume(float value)
    {
        SetMixerVolume("Music", value);
        PlayerPrefs.SetFloat("MusicVol", value);
    }

    public void SetSFXVolume(float value)
    {
        SetMixerVolume("SFX", value);
        PlayerPrefs.SetFloat("SFXVol", value);
    }

    void SetMixerVolume(string parameter, float value)
    {
        if (audioMixer == null) return;

        float dbValue = Mathf.Log10(Mathf.Max(0.0001f, value)) * 20f;
        audioMixer.SetFloat(parameter, dbValue);
    }

    //Typing speed
    public void OnTypingSpeedChanged(float value)
    {
        ApplyTypingSpeed(value);
        PlayerPrefs.SetFloat("TypingSpeed", value);
    }

    void ApplyTypingSpeed(float value)
    {
        if (dialogueManager == null)
        {
            dialogueManager = Object.FindAnyObjectByType<DialogueManager>();
        }

        if (dialogueManager != null)
        {
            dialogueManager.SetTypingSpeed(value);
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.Save();
    }

    //UI
    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }

        SaveSettings();
    }
}