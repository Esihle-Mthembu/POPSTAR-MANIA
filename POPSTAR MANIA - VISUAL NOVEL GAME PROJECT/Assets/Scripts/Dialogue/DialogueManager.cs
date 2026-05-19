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
    public CanvasGroup speakerCanvasGroup;

    [Header ("Dialogue Data")]
    public DialogueData prologueDialogue;
    public DialogueData chapter1Dialogue;
    private string currentPath = ""; 

    [Header ("Player Stats")]
    public int energyPoints;
    public int maxEnergy = 80;
    public Slider energyBar;
    public int totalEnergy = 0;

    public Slider friendshipBar;
    public int maxFriendship = 100;
    public int friendshipPoints = 50;

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

    public DialogueUIManager uIManager;


    void Awake ()
    {
        if (uiManager == null)
        {
            uiManager = FindFirstObjectByType<DialogueUIManager>();
        }
    }

    void Start()
    {
        // Link to the lyrics game completion
        if (lyricsGame != null)
        {
            lyricsGame.onLyricsGameComplete += HandleLyricsResult;
        }

        // Ensure sliders are assigned to avoid NullReferenceException
        if (energyBar == null)
        {
            // try common name first
            var go = GameObject.Find("EnergyBar");
            if (go != null) energyBar = go.GetComponent<Slider>();

            // fallback to first Slider in the scene (use new API if available)
            if (energyBar == null)
            {
                energyBar = Object.FindFirstObjectByType<Slider>();
            }

            if (energyBar == null)
            {
                Debug.LogWarning("DialogueManager: 'energyBar' not assigned in inspector and none found in scene. Assign it in the inspector.");
            }
        }

        if (energyBar != null)
        {
            energyBar.maxValue = maxEnergy;
            energyBar.value = 0;
        }

        if (energyBar != null)
        {
            energyBar.gameObject.SetActive(false);
        }

        // friendshipBar
        if (friendshipBar == null)
        {
            var go = GameObject.Find("FriendshipBar");
            if (go != null) friendshipBar = go.GetComponent<Slider>();

            if (friendshipBar == null)
            {
                // pick a different Slider than energyBar if possible
                var sliders = Object.FindObjectsByType<Slider>(FindObjectsInactive.Include, FindObjectsSortMode.None);
                foreach (var s in sliders)
                {
                    if (s != energyBar)
                    {
                        friendshipBar = s;
                        break;
                    }
                }
            }

            if (friendshipBar == null)
            {
                Debug.LogWarning("DialogueManager: 'friendshipBar' not assigned in inspector and none found in scene. Some UI features will remain hidden.");
            }
        }

        if (friendshipBar != null)
        {
            friendshipBar.gameObject.SetActive(false);
        }

        friendshipPoints = 50;
        UpdateFriendshipBar();

        // Check if a save should be loaded or start afresh
        if (PlayerPrefs.HasKey("DialogueIndex"))
        {
            LoadDialogueState();
            return;
        }
        
        StartDialogue(prologueDialogue);
    }

    void UpdateFriendshipBar()
    {
        if (friendshipBar == null) return;

        friendshipBar.maxValue = maxFriendship;
        friendshipBar.value = friendshipPoints;
    }

    public void SetTypingSpeed(float value)
    {
        typingSpeed = value;
    }

    void Update()
    {
        if (isInChoice || !isDialogueActive || currentDialogue == null || currentDialogue.lines == null)
            return;

        // defensive: ensure currentDialogue and lines exist before accessing Count
        if (currentDialogue == null || currentDialogue.lines == null || currentDialogue.lines.Count == 0)
            return;

        // Spacekey input
        bool spacePressed = false;
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            spacePressed = true;
        }
        
        if (spacePressed)
        {
            // Disable auto or skip when pressing space key
            isAutoMode = false;
            isSkipping = false;

            if (isTyping)
            {
                FinishLineInstantly();
            }
            else
            {
                // Check if this is the last line
                if (currentIndex >= currentDialogue.lines.Count - 1)
                {
                    EndDialogue(); // trigger immediatly
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

        totalEnergy = 0;
        UpdateEnergyBar();

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
        ScreenShake.Instance.StopShake();
        // stop old effects first
        ScreenFlicker.Instance.StopFlicker();
       
        // Flicker Effect
        if (currentLine.flicker)
        {
            ScreenFlicker.Instance.StartFlicker(currentLine.flickerDuration);
        }

        // Shake Effect
        if (currentLine.shake)
       {
          ScreenShake.Instance.StartShake(currentLine.shakeDuration, currentLine.shakeStrength);
       }

        // Shader Effect
        if (!string.IsNullOrEmpty(currentLine.shaderName))
        {
            SunnyShader.Instance.PlayShader(currentLine.shaderName);
        }


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

        // music BGM plays continuosly if new BGM is specified, otherwise stops if line has no BGM (can be used for silence)
        MusicManager mm = Object.FindFirstObjectByType<MusicManager>();
        AudioClip persistentClip = line.bgm;
        AudioClip overlayClip = line.backgroundMusic;


        if (mm != null)
        {
            AudioClip bgmToPlay = null;

            // Search backwards for the most recent persistent BGM
            for (int i = currentIndex; i >= 0; i--)
            {
                if (currentDialogue.lines[i].bgm != null)
                {
                    bgmToPlay = currentDialogue.lines[i].bgm;
                    break;
                }
            }

            // Play the correct persistent music
            if (bgmToPlay != null)
                mm.PlayPersistent(bgmToPlay);
            else
                mm.StopMusic();

            // Overlay music is simpler - just play if specified, stop if null (no need to search)
            if (overlayClip != null)
                mm.PlayOverlay(overlayClip);
            else
                mm.StopOverlay();
        }

        else if (AudioManager.Instance != null)
        {
            // Fallback: use central AudioManager when MusicManager is missing
            if (persistentClip != null) AudioManager.Instance.PlayMusic(persistentClip);
            else if (overlayClip != null) AudioManager.Instance.PlayMusic(overlayClip);
        }

        if (string.IsNullOrEmpty(line.speakerName))
        {
            speakerText.text = "";
            StartCoroutine(FadeSpeaker(0f));
        }
        else
        {
            speakerText.text = line.speakerName;
            StartCoroutine(FadeSpeaker(1f));
        }

        IEnumerator FadeSpeaker(float targetAlpha)
        {
            float speed = 8f;

            while (!Mathf.Approximately(speakerCanvasGroup.alpha, targetAlpha))
            {
                speakerCanvasGroup.alpha = Mathf.MoveTowards(
                    speakerCanvasGroup.alpha,
                    targetAlpha,
                    Time.deltaTime * speed
                );

                yield return null;
            }

            speakerCanvasGroup.interactable = targetAlpha > 0;
            speakerCanvasGroup.blocksRaycasts = targetAlpha > 0;
        }

        if (line.choices != null && line.choices.Length > 0)
        {
            isInChoice = true;

            if (energyBar != null && !energyBar.gameObject.activeSelf)
            {
                energyBar.gameObject.SetActive(true);
            }

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

        // Character sprites
        // Center character
        if (line.centerCharacter != null)
        {
            uiManager.centerCharacterImage.sprite = line.centerCharacter;
            uiManager.centerCharacterImage.enabled = true;
        }
        else
        {
            uiManager.centerCharacterImage.enabled = false;
        }

        // Left character
        if (line.leftCharacter != null)
        {
            uiManager.leftCharacterImage.sprite = line.leftCharacter;
            uiManager.leftCharacterImage.enabled = true;
        }
        else
        {
            uiManager.leftCharacterImage.enabled = false;
        }


        // Background
        if (line.background != null)
        {
            uiManager.backgroundImage.sprite = line.background;
        }

        typingCoroutine = StartCoroutine(TypeLine(line.dialogueText));
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

        if (currentLine.triggersLyricsGame && !lyricsGameTriggered)
        {
            lyricsGameTriggered = true;
            StartCoroutine(StartLyricsAfterDelay());
        }
    }

    IEnumerator StartLyricsAfterDelay()
    {
        yield return new WaitForSeconds(0.3f);
        TransitionToLyricsGame();
    }

    private void FinishLineInstantly()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        dialogueText.text = fullLineText;
        isTyping = false;

        if (currentLine.triggersLyricsGame && !lyricsGameTriggered)
        {
            lyricsGameTriggered = true;
            StartCoroutine(StartLyricsAfterDelay());
        }
    }

    public void TransitionToLyricsGame()
    {
        StartCoroutine(LyricsGameTransition());
    }

    IEnumerator LyricsGameTransition()
    {
        yield return StartCoroutine(fader.FadeOut());

        isDialogueActive = false;

        uiManager.gameObject.SetActive(false); // hide dialogue UI
        lyricsGame.lyricsUI.SetActive(true); // show lyrics UI
        lyricsGame.StartGame(lyricsGameData); // Start the game

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

        // Energy system
        totalEnergy += energy;
        totalEnergy = Mathf.Clamp(totalEnergy, 0, maxEnergy);
        UpdateEnergyBar();

        bool isGoodScore = (energy >= 40);

        // Friendship bar system
        if (currentPath == "A")
        {
            friendshipPoints -= 25;
        }
        else if (currentPath == "B")
        {
            friendshipPoints += 25;
        }

        friendshipPoints = Mathf.Clamp(friendshipPoints, 0, maxFriendship);
        UpdateFriendshipBar();

        // Branching
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

    void UpdateEnergyBar()
    {
        if (energyBar == null) return;

        energyBar.maxValue = maxEnergy;
        energyBar.value = totalEnergy;
    }

    public void ContinueDialogue(DialogueData data)
    {
        currentDialogue = data;
        lyricsGameTriggered = false;
        isDialogueActive = true;
        isInChoice = false;
        isAutoMode = false;
        isSkipping = false;

        currentIndex = 0; // branches start at beginning

        ShowCurrentLine();
    }

    public void EndDialogue()
    {
        // Check if prologue is done
        if (isPrologue)
        {
            Debug.Log("Prologue ended, starting chapter 1");
            StartCoroutine(HandleDialogueTransition());
            return;
        }

        if (isTyping)
        {
           FinishLineInstantly();
            return; // wait for next input instead of transitioning mid-typing
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

        // Fade to black
        yield return StartCoroutine(fader.FadeOut());
        yield return new WaitForSeconds(0.5f); // Pause while screen is black

        if (isPrologue)
        {
            isPrologue = false;
            friendshipBar.gameObject.SetActive(true);
            StartDialogue(chapter1Dialogue); // starts chapter 1 dialogue
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
        if (choice == null)
        {
            Debug.LogError("Choice is NULL");
            return;
        }

        //Stop all dialogue movement
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        isTyping = false;
        isInChoice = false;
        isSkipping = false;
        isAutoMode = false;

        if (uiManager == null)
        {
            Debug.LogError("uiManager is NOT assigned in DialogueManager!");
            return;
        }

        uiManager.ClearChoices();

        currentPath = choice.pathTag;

        //Friendship bar update
        if (currentPath == "A")
        {
            friendshipPoints -= 25;
        }
        else if (currentPath == "B")
        {
            friendshipPoints += 25;
        }

        friendshipPoints = Mathf.Clamp(friendshipPoints, 0, maxFriendship);
        UpdateFriendshipBar();

        //check before jumping
        if (choice.nextLineIndex < 0 || choice.nextLineIndex >= currentDialogue.lines.Count)
        {
            Debug.LogError("Invalid nextLineIndex: " + choice.nextLineIndex);
            return;
        }

        // Go to line/branch linked to choice made
        currentIndex = choice.nextLineIndex;
        StartCoroutine(ContinueAfterChoice());
    }

    IEnumerator ContinueAfterChoice()
    {
        yield return null;
        ShowCurrentLine();
    }

    // IN-GAME MENU BUTTONS
    // Rewind button
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

    // Auto button
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

    // Skip button
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

    // Save button
    public void SaveGame()
    {
        // Allow saving during gameplay
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

    // For loading saved game
    public void LoadDialogueState()
    {
        currentIndex = PlayerPrefs.GetInt("DialogueIndex");
        isPrologue = PlayerPrefs.GetInt("IsPrologue") == 1;
        currentDialogue = isPrologue ? prologueDialogue : chapter1Dialogue;
        isDialogueActive = true;
        ShowCurrentLine();
    }

    public void OpenSettings()
    {
        if (SettingsMenu.Instance != null)
        {
            SettingsMenu.Instance.OpenSettings();
        }
    }

    // Exit button
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
