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
    public AudioClip backgroundMusic;


    public DialogueChoice[] choices;

    public bool triggersLyricsGame;

    public bool isEnding;
    public bool isEndOfBranch;

    internal class Dialogue
    {
    }
}