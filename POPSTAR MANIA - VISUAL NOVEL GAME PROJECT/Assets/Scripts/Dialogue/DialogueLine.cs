using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    public string dialogueText;

    public DialogueLine(string characterName, string dialogueText)
    {
        this.characterName = characterName;
        this.dialogueText = dialogueText;
    }
}