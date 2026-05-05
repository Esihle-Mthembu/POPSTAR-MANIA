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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (settingsPanel == null || masterSlider == null || musicSlider == null || sfxSlider == null || typingSpeedSlider == null || audioMixer == null)
        {
            Debug.LogError("SettingsMenu: One or more references are NOT assigned in the Inspector!");
            return;
        }

        //Set default values
        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);

        //Load saved value 
        float savedSpeed = PlayerPrefs.GetFloat("TypingSpeed", 30f);
        typingSpeedSlider.value = savedSpeed;
        ApplyTypingSpeed(savedSpeed);
    }

    //UI
    public void ToggleSettings()
    {
        if (settingsPanel == null)
        {
            return;
        }

        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void OpenSettings()
    {
        Debug.Log("Open settings called");

        if (settingsPanel == null)
        {
            Debug.LogError("SettingsPanel is not assigned");
            return;
        }

        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel == null)
        {
            return;
        }

        settingsPanel.SetActive(false);
    }


    //Audio
    public void SetMasterVolume(float value)
    {
        SetMixerVolume("MasterVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        SetMixerVolume("MusicVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        SetMixerVolume("SFXVolume", value);
    }

    void SetMixerVolume(string parameter, float value)
    {
        if (audioMixer == null) return;

        float v = Mathf.Clamp(value, 0.0001f, 1f);
        audioMixer.SetFloat(parameter, Mathf.Log10(v) * 20);
    }

    //Typing speed
    public void OnTypingSpeedChanged(float value)
    {
        ApplyTypingSpeed(value);

        PlayerPrefs.SetFloat("TypingSpeed", value);
        PlayerPrefs.Save();
    }

    void ApplyTypingSpeed(float value)
    {
        if (dialogueManager != null)
        {
            dialogueManager.SetTypingSpeed(value);
        }
    }
}