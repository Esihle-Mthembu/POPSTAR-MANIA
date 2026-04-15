using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    [TextArea(1,3)]
    public string dialogueText;
    public Sprite characterSprite;
    public DialogueChoice[] choices;

    public bool hasChoices;
    public bool isEnding;

    public int nextLineIndex;

    public DialogueLine(string characterName, string dialogueText)
    {
        this.characterName = characterName;
        this.dialogueText = dialogueText;
    }
}