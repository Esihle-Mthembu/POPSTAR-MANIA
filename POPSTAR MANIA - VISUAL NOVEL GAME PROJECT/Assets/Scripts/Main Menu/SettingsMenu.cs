using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu Instance;

    public GameObject settingsPanel;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider typingSpeedSlider;

    public AudioMixer audioMixer;

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
        }
    }

    void Start()
    {
        Debug.Log($"Master: {masterSlider}, Music: {musicSlider}, SFX: {sfxSlider}, Mixer: {audioMixer}");

        if (masterSlider == null || musicSlider == null || sfxSlider == null)
        {
            Debug.LogError("One or more sliders are NOT assigned in the Inspector!");
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

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
    }

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
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}