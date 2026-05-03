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
    [CreateAssetMenu(menuName = "Dialogue/Conversation")]
    public class Dialogue : ScriptableObject
    {
        public AudioClip backgroundMusic; // background music for the scene
        public DialogueLine[] lines;
    }


    public DialogueChoice[] choices;

    public bool triggersLyricsGame;

    public bool isEnding;
    public bool isEndOfBranch;
}