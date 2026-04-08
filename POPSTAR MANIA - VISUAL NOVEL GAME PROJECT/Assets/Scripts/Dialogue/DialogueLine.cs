using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    public string dialogueText;
    public DialogueChoice[] choices;


    public bool hasChoices;
    public bool isEnding;

    public int nextLineIndex;

    public DialogueLine() { }

    public DialogueLine(string characterName, string dialogueText)
    {
        this.characterName = characterName;
        this.dialogueText = dialogueText;
    }
}