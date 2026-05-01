using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System;

public class LyricsGameManager : MonoBehaviour
{
    public TextMeshProUGUI lyricText;
    public Transform wordBankPanel;
    public GameObject wordButtonPrefab;
    public Slider energyBar;

    public System.Action<int, int> onLyricsGameComplete;

    int totalEnergy = 0;

    private string maskedLine;
    private string[] currentFilledWords;
    public List<string> selectedWords = new List<string>();

    public LyricsGameData currentGame;
    private int currentLineIndex = 0;
    private int currentBlankIndex = 0;

    public GameObject lyricsUI;

    public void StartGame(LyricsGameData data)
    {
        Debug.Log("Start game called");

        currentGame = data;
        currentLineIndex = 0;

        ShowCurrentLine();
    }

    //Hiding words
    public string GetMaskedLine(LyricLines line)
    {
        string result = line.fullLine;

        foreach (string word in line.missingWords)
        {
            result = ReplaceFirst(result, word, "____");
        }

        return result;

        string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }

            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }

    public void ShowCurrentLine()
    {
        if (currentGame == null)
        {
            Debug.LogError("LyricsGameData is NOT assigned!");
            return;
        }

        if (currentGame.lines == null || currentGame.lines.Length == 0)
        {
            Debug.LogError("LyricsGameData has NO lines!");
            return;
        }

        if (currentLineIndex < 0 || currentLineIndex >= currentGame.lines.Length)
        {
            Debug.LogWarning("CurrentLineIndex out of range. Ending game safely.");
            EndGame();
            return;
        }

        Debug.Log("Lines: " + currentGame.lines.Length);
        Debug.Log("Index: " + currentLineIndex);

        LyricLines line = currentGame.lines[currentLineIndex];
        currentFilledWords = new string[line.missingWords.Length];

        //reset state
        currentBlankIndex = 0;
        selectedWords.Clear();

        //set display
        maskedLine = line.fullLine;

        for (int i = 0; i < line.missingWords.Length; i++)
        {
            maskedLine = ReplaceFirst(maskedLine, line.missingWords[i], "____");
        }

        lyricText.text = maskedLine;

        //Generate words
        GenerateWordBank(line);
    }

    //Interactivity
    void GenerateWordBank(LyricLines line)
    {
        //clears old buttons
        foreach (Transform child in wordBankPanel)
        {
            Destroy(child.gameObject);
        }

        List<string> words = new List<string>();

        //Adding correct words
        words.AddRange(line.missingWords);//correct answers
        words.AddRange(line.extraWords);//wrong answers

        //shuffle
        for (int i = 0; i < words.Count; i++)
        {
            int rand = UnityEngine.Random.Range(0, words.Count);
            (words[i], words[rand]) = (words[rand], words[i]);

        }

        //Buttons
        foreach (string word in words)
        {
            GameObject btnObj = Instantiate(wordButtonPrefab, wordBankPanel);

            TextMeshProUGUI btnText = btnObj.GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = word;

            Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(() => SelectWord(word, btn));
        }
    }

    //Word selection
    public void SelectWord(string word, Button btn)
    {
        LyricLines line = currentGame.lines[currentLineIndex];

        // safety
        if (currentBlankIndex >= line.missingWords.Length)
            return;

        selectedWords.Add(word);

        // fill next blank immediately
        FillBlank(word);

        btn.interactable = false;

        Debug.Log("Placed: " + word);
    }

    void FillBlank(string word)
    {
        LyricLines line = currentGame.lines[currentLineIndex];

        if (currentBlankIndex >= currentFilledWords.Length)
            return;

        currentFilledWords[currentBlankIndex] = word;
        currentBlankIndex++;

        string result = maskedLine;
        int searchStart = 0;

        for (int i = 0; i < currentFilledWords.Length; i++)
        {
            int blankIndex = result.IndexOf("____", searchStart);

            if (blankIndex == -1)
                break;

            string replacement = currentFilledWords[i];

            if (string.IsNullOrEmpty(replacement))
                replacement = "____";

            result =
                result.Substring(0, blankIndex) +
                replacement +
                result.Substring(blankIndex + 4);

            searchStart = blankIndex + replacement.Length;
        }

        lyricText.text = result;
    }

    string ReplaceFirst(string text, string search, string replace)
    {
        int pos = text.IndexOf(search);
        if (pos < 0) return text;

        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }

    public void OnSubmitPressed()
    {
        if (selectedWords.Count == 0)
        {
            Debug.Log("No words selected");
            return;
        }
        SubmitAnswer(selectedWords.ToArray());
    }

    //Choosing answers
    public void SubmitAnswer(string[] playerAnswers)
    {
        LyricLines line = currentGame.lines[currentLineIndex];
        int correctThisLine = 0;

        for (int i = 0; i < line.missingWords.Length; i++)
        {
            //Check if player provided enough answers and if they match
            if (i < playerAnswers.Length && playerAnswers[i] == line.missingWords[i])
            {
                 correctThisLine++;
            }
        }

        //Accumulating a score
        totalEnergy += correctThisLine * 20; //20 points per correct blank word in lyrics challenge

        NextLine();
    }

    //Change lines
    public void NextLine()
    {
        currentLineIndex++;

        if (currentLineIndex < currentGame.lines.Length)
        {
            ShowCurrentLine();
        }
        else
        {
            EndGame();
        }
    }

    //End of lyric game
    public void EndGame()
    {
        lyricsUI.SetActive(false);

        Debug.Log("Final Energy: " + totalEnergy);

        //Send result back
        onLyricsGameComplete?.Invoke(totalEnergy, 80);
    }
}
