using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    [TextArea(2, 5)]
    public string line;

    public DialogueLine(string name, string text)
    {
        characterName = name;
        line = text;
    }
}

public class Chapter1 : MonoBehaviour
{
    // UI fields
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    // Dialogue data stored in an array of DialogueLine
    private DialogueLine[] dialogueLines;

    private int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player presses the Space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextLine();
        }
    }
}
