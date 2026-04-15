using System.Collections;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public DialogueLine[] dialogueLines;
    public int index = 0;

    public float typingSpeed = 0.5f;

    public bool isTyping = false;
    public bool isAuto = false;
    public bool isSkipping = false;

    void Start()
    {
        ShowCurrentLine();
    }

    public void ShowCurrentLine()
    {
        if (dialogueLines == null || dialogueLines.Length == 0)
        {
            Debug.LogError("No dialogue lines assigned!");
            return;
        }

        if (index >= dialogueLines.Length)
        {
            Debug.Log("End of dialogue");
            return;
        }

        StopAllCoroutines();
        StartCoroutine(TypeLine(dialogueLines[index]));
    }

    public DialogueUIManager uiManager;
    IEnumerator TypeLine(DialogueLine line)
    {
        isTyping = true;

        uiManager.SetName(line.characterName);
        uiManager.SetText("");

        foreach (char c in line.dialogueText)
        {
            uiManager.AppendText(c.ToString());
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;

        // Show choices if available
        if (line.hasChoices && line.choices != null && line.choices.Length > 0)
        {
            uiManager.ShowChoices(line.choices);
        }
    }

    public void NextLine()
    {
        if (dialogueLines == null || dialogueLines.Length == 0) return;

        if (isTyping)
        {
            StopAllCoroutines();
            isTyping = false;

            var line = dialogueLines[index];
            uiManager.SetText(line.dialogueText);

            return;
        }

        index++;

        if (index < dialogueLines.Length)
        {
            ShowCurrentLine();
        }
        else
        {
            Debug.Log("End of dialogue");
        }
    }

    public void Rewind()
    {
        if (index > 0)
        {
            index--;
            ShowCurrentLine();
        }
    }

    public void ToggleAuto()
    {
        isAuto = !isAuto;

        if (isAuto)
            StartCoroutine(AutoPlay());
    }

    IEnumerator AutoPlay()
    {
        while (isAuto)
        {
            yield return new WaitForSeconds(2f);

            if (!isTyping)
                NextLine();
        }
    }

    public void StartSkip()
    {
        isSkipping = true;
        StartCoroutine(Skip());
    }

    public void StopSkip()
    {
        isSkipping = false;
    }

    IEnumerator Skip()
    {
        while (isSkipping)
        {
            yield return null;

            if (!isTyping)
                NextLine();
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("DialogueIndex", index);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("DialogueIndex"))
        {
            index = PlayerPrefs.GetInt("DialogueIndex");
            ShowCurrentLine();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            NextLine();
        }
    }

    public void OnChoiceSelected(DialogueChoice choice)
    {
        index = choice.nextLineIndex;
        ShowCurrentLine();
    }
}