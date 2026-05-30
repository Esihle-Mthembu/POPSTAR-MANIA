using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic; 

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu Instance;

    [Header("UI")]
    public GameObject settingsPanel;

    [Header("Sliders")]
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider typingSpeedSlider;

    [Header("Audio")]
    public AudioMixer audioMixer;

    [Header("Dialogue")]
    public DialogueManager dialogueManager;

    // Typing speed range
    private const float TypingSpeedMin = 10f;
    private const float TypingSpeedMax = 60f;

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
        RegisterSliderListeners();
        LoadSettings();
    }

    
    void RegisterSliderListeners()
    {
        if (masterSlider != null)
        {
            masterSlider.onValueChanged.RemoveAllListeners();
            masterSlider.onValueChanged.AddListener(SetMasterVolume);
        }
        if (musicSlider != null)
        {
            musicSlider.onValueChanged.RemoveAllListeners();
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }
        if (sfxSlider != null)
        {
            sfxSlider.onValueChanged.RemoveAllListeners();
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
        if (typingSpeedSlider != null)
        {
            // Enforce the correct range on the slider itself
            typingSpeedSlider.minValue = TypingSpeedMin;
            typingSpeedSlider.maxValue = TypingSpeedMax;
            typingSpeedSlider.onValueChanged.RemoveAllListeners();
            typingSpeedSlider.onValueChanged.AddListener(OnTypingSpeedChanged);
        }
    }

    void LoadSettings()
    {
        // Load saved values, with defaults
        float master = PlayerPrefs.GetFloat("MasterVol", 0.75f);
        float music = PlayerPrefs.GetFloat("MusicVol", 0.75f);
        float sfx = PlayerPrefs.GetFloat("SFXVol", 0.75f);
        float speed = PlayerPrefs.GetFloat("TypingSpeed", 30f); //default matches DialogueManager

        // Set slider values
        if (masterSlider != null) masterSlider.value = master;
        if (musicSlider != null) musicSlider.value = music;
        if (sfxSlider != null) sfxSlider.value = sfx;
        if (typingSpeedSlider != null) typingSpeedSlider.value = speed;

        ApplyMixerVolume("Master", master);
        ApplyMixerVolume("Music", music);
        ApplyMixerVolume("SFX", sfx);
        ApplyTypingSpeed(speed);
    }

    //Volume
    public void SetMasterVolume(float value)
    {
        ApplyMixerVolume("Master", value);
        PlayerPrefs.SetFloat("MasterVol", value);
    }

    public void SetMusicVolume(float value)
    {
        ApplyMixerVolume("Music", value);
        PlayerPrefs.SetFloat("MusicVol", value);
    }

    public void SetSFXVolume(float value)
    {
        ApplyMixerVolume("SFX", value);
        PlayerPrefs.SetFloat("SFXVol", value);
    }

    void ApplyMixerVolume(string parameter, float value)
    {
        if (audioMixer == null)
        {
            Debug.LogWarning($"[SettingsMenu] AudioMixer not assigned — cannot set '{parameter}'");
            return;
        }

        float db = Mathf.Log10(Mathf.Max(0.0001f, value)) * 20f;
        bool success = audioMixer.SetFloat(parameter, db);

        if (!success)
        {
            Debug.LogWarning($"[SettingsMenu] AudioMixer has no exposed parameter named '{parameter}'. " +
                             "Check Window > Audio > AudioMixer > Expose and confirm the exact name.");
        }
    }

    //Typing Speed
    public void OnTypingSpeedChanged(float value)
    {
        ApplyTypingSpeed(value);
        PlayerPrefs.SetFloat("TypingSpeed", value);
    }

    void ApplyTypingSpeed(float value)
    {
        if (dialogueManager == null)
            dialogueManager = Object.FindAnyObjectByType<DialogueManager>();

        if (dialogueManager != null)
        {
            dialogueManager.SetTypingSpeed(value);
        }
        else
        {
            Debug.LogWarning("[SettingsMenu] DialogueManager not found — typing speed will be applied when available.");
        }
    }

    public void RefreshAfterSceneLoad()
    {
        dialogueManager = Object.FindAnyObjectByType<DialogueManager>();
        float speed = PlayerPrefs.GetFloat("TypingSpeed", 30f);
        ApplyTypingSpeed(speed);
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

        PlayerPrefs.Save();
    }
}