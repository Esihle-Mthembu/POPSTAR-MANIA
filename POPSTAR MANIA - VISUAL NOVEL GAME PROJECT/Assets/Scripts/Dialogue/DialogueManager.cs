using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI dialogueText;

    public DialogueUIManager uiManager;

    public DialogueData prologueDialogue;
    public DialogueData chapter1Dialogue;

    private DialogueData currentDialogue;
    private int currentIndex;

    private bool isPrologue = true;
    private bool isDialogueActive = true;
    private bool waitingForChoice = false;

    public void StartGame()
    {
        StartDialogue(prologueDialogue);
    }

    public void StartDialogue(DialogueData dialogueData)
    {
        currentDialogue = dialogueData;
        currentIndex = 0;

        isDialogueActive = true;

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        currentIndex++;

        if (currentIndex >= currentDialogue.lines.Count)
        {
            EndDialogue();
            return;
        }

        ShowCurrentLine();
    }

    public void ShowCurrentLine()
    {
        DialogueLine line = currentDialogue.lines[currentIndex];

        uiManager.SetLine(line);

        if (line.choices != null && line.choices.Length > 0)
        {
            uiManager.ShowChoices(line.choices);
            return;
        }

        // Hiding choices if line has none
        if (line.choices == null || line.choices.Length == 0)
        {
            uiManager.ClearChoices();
        }

        if (line.isEndOfBranch)
        {
            EndDialogue();
            return;
        }
    }

    public void SelectChoice(DialogueChoice choice)
    {
        uiManager.ClearChoices(); // hide panel + buttons

        currentIndex = choice.nextLineIndex;

        ShowCurrentLine();
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (currentDialogue == null)
                return;

            if (currentIndex >= currentDialogue.lines.Count)
            {
                EndDialogue();
                return;
            }

            if (!isDialogueActive)
                return;

            if (waitingForChoice)
                return;

            DialogueLine line = currentDialogue.lines[currentIndex];

            // Blocks skipping during choices
            if (line.choices != null && line.choices.Length > 0)
                return;

            DisplayNextLine();
        }
    }

    void EndDialogue()
    {
        Debug.Log("Dialogue Finished");

        uiManager.ClearChoices();

        //IF WE ARE IN PROLOGUE GO TO CHAPTER 1
        if (isPrologue && chapter1Dialogue != null)
        {
            isPrologue = false;
            StartDialogue(chapter1Dialogue);
            return;
        }

        //OTHERWISE END THE GAME
        speakerText.text = "";
        dialogueText.text = "";

        isDialogueActive = false;

        gameObject.SetActive(false);
    }
}
