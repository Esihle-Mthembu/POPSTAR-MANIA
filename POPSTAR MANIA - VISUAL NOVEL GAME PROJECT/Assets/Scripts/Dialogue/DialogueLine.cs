using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string speakerName;

    [TextArea(3, 5)]
    public string dialogueText;

    public Sprite centerCharacter;
    public Sprite leftCharacter;
    public Sprite background;

    [Header("Audio")]
    public AudioClip backgroundMusic;
    public AudioClip bgm;
   
    [Header("Effects")]
    public bool flicker;
    public float flickerDuration = 1f;

    [Header("Shader")]
    public string shaderName;

    public bool shake;
    public float shakeDuration = 0.5f;
    public float shakeStrength = 5f;

    public DialogueChoice[] choices;

    public bool triggersLyricsGame;

    public bool isEnding;
    public bool isEndOfBranch;

    public bool triggersMessage;
    public string messageText;

    internal class Dialogue
    {
    }
}