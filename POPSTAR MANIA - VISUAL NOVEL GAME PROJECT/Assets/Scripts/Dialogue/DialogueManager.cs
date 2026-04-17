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
    private bool isInChoice = false;

    void Start()
    {
        //Loading from saved progress
        if (PlayerPrefs.HasKey("DialogueIndex"))
        {
            LoadDialogueState();
        }
        else
        {
            //Normal game start
            StartGame();
        }
    }

    void LoadDialogueState ()
    {
        currentIndex = PlayerPrefs.GetInt("DialogueIndex");
        isPrologue = PlayerPrefs.GetInt("IsPrologue") == 1;

        if (isPrologue)
            currentDialogue = prologueDialogue;
        else
            currentDialogue = chapter1Dialogue;

        isDialogueActive=true;

        StartCoroutine(DelayedLoad()); //delays frame
    }

    IEnumerator DelayedLoad()
    {
        yield return null;
        ShowCurrentLine();
        Debug.Log("Loaded at index: " + currentIndex);
    }

    public void StartGame()
    {
        if (PlayerPrefs.HasKey("DialogueIndex"))
            return;

        StartDialogue(prologueDialogue);
    }

    public void StartDialogue(DialogueData dialogueData)
    {
        currentDialogue = dialogueData;
        currentIndex = 0;

        isDialogueActive = true;

        ShowCurrentLine();
    }

    public void DisplayNextLine()
    {
        if (isInChoice)
            return;
        
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

        // Choices first
        if (line.choices != null && line.choices.Length > 0)
        {
            isInChoice = true; //locks any other input 
            isAutoMode = false;
            isSkipping = false;
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

        // End branch check after starting logic is fine
        if (line.isEndOfBranch)
        {
            EndDialogue();
            return;
        }
    }

    public void SelectChoice(DialogueChoice choice)
    {
        isInChoice = false; //unlocks input
        uiManager.ClearChoices(); // hide panel and choice buttons
        currentIndex = choice.nextLineIndex;

        ShowCurrentLine();
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        if (isInChoice)
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
            currentIndex -= 2; // move back
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

        if (isInChoice)
        {
            yield return null;
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
        if (isInChoice)
            yield return null;

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

            // Pacing
            yield return new WaitForSeconds(0.25f);

            DisplayNextLine();
        }
    }

    //Save button
    public void SaveGame()
    {
        //Allow saving during gameplay
        if (currentDialogue == null  || !isDialogueActive)
        {
            Debug.Log("Cannot save right now");
            return;
        }

        PlayerPrefs.SetInt("DialogueIndex", currentIndex); 
        PlayerPrefs.SetInt("IsPrologue", isPrologue? 1:0);
        PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);

        PlayerPrefs.Save();

        Debug.Log("Game Saved");
    }

    //For loading saved game
    public void LoadGame()
    {
        if (!PlayerPrefs.HasKey("DialogueIndex"))
        {
            Debug.Log("No save found");
            return;
        }

        string sceneName = PlayerPrefs.GetString("SceneName");
        SceneManager.LoadScene(sceneName);
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
