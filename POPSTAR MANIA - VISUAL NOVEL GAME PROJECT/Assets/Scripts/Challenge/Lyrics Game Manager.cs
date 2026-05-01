using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class LyricsGameManager : MonoBehaviour
{
    public TextMeshProUGUI lyricText;
    public Transform wordBankPanel;
    public GameObject wordButtonPrefab;

    public List<string> selectedWords = new List<string>();

    public LyricsGameData currentGame;
    private int currentLineIndex = 0;
    private int energy = 0;

    public GameObject lyricsUI;

    void Start()
    {
        LyricsGameData testData = new LyricsGameData();

        testData.lines = new LyricLines[3];

        testData.lines[0] = new LyricLines
        {
            fullLine = "I will survive tonight",
            missingWords = new string[] { "survive" }
        };

        testData.lines[1] = new LyricLines
        {
            fullLine = "We dance in the dark",
            missingWords = new string[] { "dance", "dark" }
        };

        testData.lines[2] = new LyricLines
        {
            fullLine = "Feel the fire inside",
            missingWords = new string[] { "fire" }
        };

        StartGame(testData);
    }

    public void StartGame(LyricsGameData data)
    {
        lyricsUI.SetActive(true);

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
            result = result.Replace(word, "____");
        }

        return result;
    }

    public void ShowCurrentLine()
    {
        selectedWords.Clear();
        LyricLines line = currentGame.lines[currentLineIndex];
        string masked = GetMaskedLine(line);
        lyricText.text = masked;

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
        words.AddRange(line.missingWords);

        for (int i = 0; i < words.Count; i++)
        {
            string temp = words[i];
            int randomIndex = Random.Range(0, words.Count);
            words [i] = words[randomIndex];
            words [randomIndex] = temp;
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
        selectedWords.Add(word);
        btn.interactable = false; //preventing double click

        Debug.Log("Selected: " + word);
    }

    public void OnSubmitPressed()
    {
        SubmitAnswer(selectedWords.ToArray());
    }

    //Choosing answers
    public void SubmitAnswer(string[] playerAnswers)
    {
        LyricLines line = currentGame.lines[currentLineIndex];
        int correct = 0;

        for (int i = 0; i < line.missingWords.Length; i++)
        {
            if (playerAnswers[i] == line.missingWords[i])
            {
                correct++;
            }
        }

        energy += correct * 2;

        Debug.Log("Correct words: " + correct);
        Debug.Log("Energy: " + energy);

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

        Debug.Log("Lyrics game finished");
        Debug.Log("Final energy: " + energy);
    }
}
