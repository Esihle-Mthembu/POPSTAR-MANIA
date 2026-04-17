using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
    public float typingSpeed = 30f;

    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI dialogueText;

    public DialogueUIManager uiManager;

    public DialogueData prologueDialogue;
    public DialogueData chapter1Dialogue;

    private DialogueData currentDialogue;
    private int currentIndex;

    private bool isTyping;
    private bool isPrologue = true;
    private bool isDialogueActive = true;
    private bool waitingForChoice = false;

    private bool isAutoMode = false;
    private bool isSkipping = false;

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

        // Speaker
        speakerText.text = line.speakerName;

        // Choices FIRST (so UI logic is correct)
        if (line.choices != null && line.choices.Length > 0)
        {
            uiManager.ShowChoices(line.choices);
            return;
        }

        uiManager.ClearChoices();

        // Stop previous typing
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // Start typing
        typingCoroutine = StartCoroutine(TypeLine(line.dialogueText));

        if (line.characterSprite != null)
            uiManager.characterImage.sprite = line.characterSprite;

        if (line.background != null)
            uiManager.backgroundImage.sprite = line.background;

        // End branch check AFTER starting logic is fine
        if (line.isEndOfBranch)
        {
            EndDialogue();
            return;
        }
    }

    public void SelectChoice(DialogueChoice choice)
    {
        uiManager.ClearChoices(); // hide panel and choice buttons

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

            // block skipping during choices
            if (line.choices != null && line.choices.Length > 0)
                return;

            // ONLY go to next line if typing is finished
            if (isTyping)
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

    Coroutine typingCoroutine;
    string fullLineText;

    IEnumerator TypeLine(string line)
    {
        isTyping = true;

        dialogueText.text = "";
        fullLineText = line;

        foreach (char letter in line)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / typingSpeed);
        }

        isTyping = false;
    }

    //IN-GAME MENU BUTTONS

    //Rewind button
    public void Rewind()
    {
        if (currentIndex > 0)
        {
            currentIndex -= 2; // step back correctly
            DisplayNextLine();
        }
    }

    //Auto button
    IEnumerator AutoPlay()
    {
        while (isAutoMode)
        {
            if (!isTyping)
            {
                DisplayNextLine();
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ToggleAuto()
    {
        isAutoMode = !isAutoMode;

        if (isAutoMode)
            StartCoroutine(AutoPlay());
    }

    //Skip button
    public void ToggleSkip()
    {
        isSkipping = !isSkipping;

        if (isSkipping)
        {
            StartCoroutine(SkipDialogue());
        }
    }

    IEnumerator SkipDialogue()
    {
        while (isSkipping)
        {
            if (currentDialogue == null)
                yield break;

            // Finish typing instantly if still typing
            if (isTyping)
            {
                dialogueText.text = fullLineText;
                isTyping = false;
            }

            // Wait until typing is fully finished
            yield return new WaitUntil(() => !isTyping);

            // SMALL CONTROLLED DELAY
            yield return new WaitForSeconds(0.08f);

            DisplayNextLine();
        }
    }

    //Save button
    public void SaveGame()
    {
        PlayerPrefs.SetInt("DialogueIndex", currentIndex);
        PlayerPrefs.Save();
    }

    //For loading saved game later
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("DialogueIndex"))
        {
            currentIndex = PlayerPrefs.GetInt("DialogueIndex");
            ShowCurrentLine();
        }
    }

    public void ToggleSettings()
    {
        if (SettingsMenu.Instance != null)
        {
            SettingsMenu.Instance.ToggleSettings();
        }
    }

    //Exit button
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
