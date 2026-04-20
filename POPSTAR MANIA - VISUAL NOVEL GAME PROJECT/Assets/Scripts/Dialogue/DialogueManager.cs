using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header ("UI References")]
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI dialogueText;
    public DialogueUIManager uiManager;
    public float typingSpeed = 30f;

    [Header ("Dialogue Data")]
    public DialogueData prologueDialogue;
    public DialogueData chapter1Dialogue;
    private string currentPath = ""; 

    [Header ("Player Stats")]
    public int energyPoints;
    public int friendshipPoints;

    [Header ("Game Refernces")]
    public LyricsGameManager lyricsGame;
    public LyricsGameData lyricsGameData;

    [Header ("Result Branches")]
    public DialogueData A_Good;
    public DialogueData A_Bad;
    public DialogueData B_Good;
    public DialogueData B_Bad;

    private DialogueData currentDialogue;
    private int currentIndex;
    private bool isTyping;
    private bool isPrologue = true;
    private bool isDialogueActive = true;
    private bool isInChoice = false;
    private bool isAutoMode = false;
    private bool isSkipping = false;
    private Coroutine typingCoroutine;
    private string fullLineText;

    public bool loadingFromSave = false;
    private bool isTransitioning = false;
    private bool lyricsGameTriggered = false;

    private HashSet<int> triggeredLines = new HashSet<int>();
    private DialogueLine currentLine;
    public ScreenFader fader;

    void Start()
    {
        //Link to the lyrics game completion
        if (lyricsGame != null)
        {
            lyricsGame.onLyricsGameComplete += HandleLyricsResult;
        }

        //Check if a save should be loaded or start afresh
        if (PlayerPrefs.HasKey("DialogueIndex"))
        {
            LoadDialogueState();
            return;
        }
        
            StartDialogue(prologueDialogue);
    }

    void Update()
    {
        if (isInChoice || !isDialogueActive)
            return;

        //Spacekey input
        bool spacePressed = false;
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            spacePressed = true;
        }
        
        if (spacePressed)
        {
            //Disable auto or skip when pressing space key
            isAutoMode = false;
            isSkipping = false;

            if (isTyping)
            {
                FinishLineInstantly();
            }
            else
            {
                //Check if this is the last line
                if (currentIndex >= currentDialogue.lines.Count - 1)
                {
                    EndDialogue(); //trigger immediatly
                }
                else
                {
                    DisplayNextLine();
                }
            }
        }
    }

    public void StartDialogue(DialogueData data)
    {
        currentDialogue = data;
        currentIndex = 0;

        isDialogueActive = true;
        isPrologue = (data == prologueDialogue);
        isInChoice = false;
        isAutoMode = false;
        isSkipping = false;

        currentPath = "";
        triggeredLines.Clear();

        ShowCurrentLine();
    }

    public void DisplayNextLine()
    {
        if (isInChoice || currentDialogue == null || isTyping || isTransitioning)
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
        if (currentDialogue == null || currentIndex >= currentDialogue.lines.Count)
            return;

        currentLine = currentDialogue.lines[currentIndex];
        DialogueLine line = currentLine;
        speakerText.text = line.speakerName;

        if (line.choices != null && line.choices.Length > 0)
        {
            isInChoice = true;
            uiManager.ShowChoices(line.choices);
        }
        else
        {
            isInChoice = false;
            uiManager.ClearChoices();
        }

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        //only trigger lyrics game after typing finishes
        if (currentLine.triggersLyricsGame && !lyricsGameTriggered)
        {
            lyricsGameTriggered = true;
            StartCoroutine(TriggerLyricsAfterTyping());
        }

        typingCoroutine = StartCoroutine(TypeLine(line.dialogueText));

        if (line.characterSprite != null)
        {
            uiManager.characterImage.sprite = line.characterSprite;
        }

        if (line.background != null)
        {
            uiManager.backgroundImage.sprite = line.background;
        }
    }

    IEnumerator TriggerLyricsAfterTyping()
    {
        // wait until typing finishes
        while (isTyping)
            yield return null;

        yield return new WaitForSeconds(0.3f);

        TransitionToLyricsGame();
    }

    IEnumerator TypeLine(string text)
    {
        isTyping = true;
        fullLineText = text;
        dialogueText.text = "";

        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / typingSpeed);
        }

        isTyping = false;
    }

    private void FinishLineInstantly()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        dialogueText.text = fullLineText;
        isTyping = false;
    }

    public void TransitionToLyricsGame()
    {
        StartCoroutine(LyricsGameTransition());
    }

    IEnumerator LyricsGameTransition()
    {
        yield return StartCoroutine(fader.FadeOut());

        isDialogueActive = false;

        uiManager.gameObject.SetActive(false); //hide dialogue UI
        lyricsGame.lyricsUI.SetActive(true); //show lyrics UI
        lyricsGame.StartGame(lyricsGameData); //Start the game

        yield return StartCoroutine(fader.FadeIn());
    }

    void HandleLyricsResult(int energy, int total)
    {
        Debug.Log("=== LYRICS RESULT ===");
        Debug.Log("Energy: " + energy);
        Debug.Log("Path: '" + currentPath);

        StartCoroutine(ReturnFromLyrics(energy, total));
    }

    IEnumerator ReturnFromLyrics(int energy, int total)
    {
        yield return StartCoroutine(fader.FadeOut());

        isDialogueActive = true;
        uiManager.gameObject.SetActive(true);

        bool isGoodScore = (energy >= 40);

        if (currentPath == "A")
        {
            if (isGoodScore)
            {
                ContinueDialogue(A_Good);
            }
            else
            {
                ContinueDialogue(A_Bad);
            }
        }
        else if (currentPath == "B")
        {
            if (isGoodScore)
            {
                ContinueDialogue(B_Good);
            }
            else
            {
                ContinueDialogue(B_Bad);
            }
        }

        yield return StartCoroutine(fader.FadeIn());
    }

    public void ContinueDialogue(DialogueData data)
    {
        currentDialogue = data;
        lyricsGameTriggered = false;
        isDialogueActive = true;
        isInChoice = false;
        isAutoMode = false;
        isSkipping = false;

        // DO NOT reset triggeredLines
        // DO NOT reset currentPath
        // DO NOT reset index to 0 blindly (unless intended)

        currentIndex = 0; // branches start at beginning

        ShowCurrentLine();
    }

    public void EndDialogue()
    {
        //Check if prologue is done
        if (isPrologue)
        {
            Debug.Log("Prologue ended, starting chapter 1");
            StartCoroutine(HandleDialogueTransition());
            return;
        }

        if (isTyping)
        {
           FinishLineInstantly();
            return; //wait for next input instead of transitioning mid-typing
        }

        Debug.Log("Dialogue finished");

        isDialogueActive = false;
        isAutoMode = false;
        isSkipping = false;
        uiManager.ClearChoices();

        StartCoroutine(HandleDialogueTransition());
    }

    IEnumerator HandleDialogueTransition()
    {
        isTransitioning = true;
        isSkipping = false;
        isAutoMode = false;

        if (fader == null)
        {
            Debug.LogError("Fader not assigned!");
            yield break;
        }

        //Fade to black
        yield return StartCoroutine(fader.FadeOut());
        yield return new WaitForSeconds(0.5f); //Pause while screen is black

        if (isPrologue)
        {
            isPrologue = false;
            StartDialogue(chapter1Dialogue); //starts chapter 1 dialogue
        }
        else
        {
            Debug.Log("No further dialogue assigned");
        }

        // Fade back in
        yield return StartCoroutine(fader.FadeIn());

        isTransitioning = false;
    }

    public void SelectChoice(DialogueChoice choice)
    {
        isInChoice = false;
        uiManager.ClearChoices();

        DialogueLine currentLine = currentDialogue.lines[currentIndex];

        if (choice == null)
        {
            Debug.LogError("Choice is NULL");
            return;
        }

        currentPath = choice.pathTag;

        Debug.Log("Choice selected Path: " + currentPath);

        //Go to line/branch linked to choice made
        currentIndex = choice.nextLineIndex;
        ShowCurrentLine();
    }

    //IN-GAME MENU BUTTONS
    //Rewind button
    public void Rewind()
    {
        if (isTransitioning)
        {
            return;
        }

        if (currentIndex > 0)
        {
            currentIndex --; // move back
            ShowCurrentLine();
        }
    }

    //Auto button
    public void ToggleAuto()
    {
        isAutoMode = !isAutoMode;

        if (isAutoMode)
        {
            StartCoroutine(AutoPlay());
        }
    }

    IEnumerator AutoPlay()
    {
        while (isAutoMode && isDialogueActive)
        {
            if (!isTyping && !isInChoice)
            {
                yield return new WaitForSeconds(1.5f);
                DisplayNextLine();
            }

            yield return null;
        }
    }

    //Skip button
    public void ToggleSkip()
    {
        if (isTransitioning) return;

        isSkipping = !isSkipping;
        isAutoMode = false;

        if (isSkipping)
        {
            StartCoroutine(SkipDialogue());
        }
    }

    IEnumerator SkipDialogue()
    {
        while (isSkipping && isDialogueActive)
        {
            if (isTransitioning)
            {
                yield break;
            }

            if (isInChoice)
            {
                isSkipping = false;
                yield break;
            }

            if (isTyping)
            {
                FinishLineInstantly();
            }
            else
            {
                DisplayNextLine();
            }

            yield return new WaitForSeconds(0.25f);
        }
    }

    //Save button
    public void SaveGame()
    {
        //Allow saving during gameplay
        if (currentDialogue == null  || !isDialogueActive)
        {
            return;
        }

        PlayerPrefs.SetInt("DialogueIndex", currentIndex); 
        PlayerPrefs.SetInt("IsPrologue", isPrologue? 1:0);
        PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();

        Debug.Log("Game Saved");
    }

    //For loading saved game
    public void LoadDialogueState()
    {
        currentIndex = PlayerPrefs.GetInt("DialogueIndex");
        isPrologue = PlayerPrefs.GetInt("IsPrologue") == 1;
        currentDialogue = isPrologue ? prologueDialogue : chapter1Dialogue;
        isDialogueActive = true;
        ShowCurrentLine();
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
