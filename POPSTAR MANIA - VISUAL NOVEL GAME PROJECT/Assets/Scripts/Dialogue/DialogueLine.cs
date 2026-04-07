using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    public string dialogue;

    public bool hasChoices;
    public DialogueChoice[] choices;

    public int nextIndex;

    // ✅ ADD THIS (fixes ALL 880 errors instantly)
    public DialogueLine() { }

    // ✅ ADD THIS CONSTRUCTOR (supports your old code)
    public DialogueLine(string characterName, string dialogue)
    {
        this.characterName = characterName;
        this.dialogue = dialogue;
    }
}