using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string speakerName;

    [TextArea(3, 5)]
    public string dialogueText;

    public Sprite characterSprite;
    public Sprite characterSprite2;
    public Sprite background;

    public DialogueChoice[] choices;

    public bool triggersLyricsGame;

    public bool isEnding;
    public bool isEndOfBranch;
}