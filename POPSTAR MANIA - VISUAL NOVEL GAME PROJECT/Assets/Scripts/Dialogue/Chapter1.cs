using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chapter1 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    private List<string> chapter1Lines;
    private int chapter1Index;

    void Start()
    {
        chapter1Lines = new List<string>()
        {
            "Chapter 1 begins...",
            "You wake up in an unfamiliar room.",
            "Something feels off..."
        };

        chapter1Index = 0;
        ShowLine();
    }

    public void NextLine()
    {
        chapter1Index++;
        ShowLine();
    }

    void ShowLine()
    {
        if (chapter1Index < chapter1Lines.Count)
        {
            dialogueText.text = chapter1Lines[chapter1Index];
        }
    }
}
