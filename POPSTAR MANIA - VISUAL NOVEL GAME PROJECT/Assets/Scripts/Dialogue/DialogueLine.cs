using UnityEngine;

public enum PopupAction
{
    None,
    Show,
    Hide
}

[System.Serializable]
public class DialogueLine
{
    public string speakerName;

    [TextArea(3, 5)]
    public string dialogueText;

    public Sprite centerCharacter;
    public Sprite leftCharacter;
    public Sprite background;
    public AudioClip backgroundMusic;
    public AudioClip bgm;

    //PopUp system
    public PopupAction popupAction;
    public Sprite popupImage;
   
    [Header("Effects")]
    public bool flicker;
    public float flickerDuration = 1f;

    //public bool shake;
    //public float shakeDuration = 0.5f;
    //public float shakeStrength = 5f;

    public DialogueChoice[] choices;

    public bool triggersLyricsGame;

    public bool isEnding;
    public bool isEndOfBranch;

    internal class Dialogue
    {
    }
}