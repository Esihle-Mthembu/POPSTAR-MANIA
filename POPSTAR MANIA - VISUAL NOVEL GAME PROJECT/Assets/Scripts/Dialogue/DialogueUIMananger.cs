using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUIManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Transform choicesParent;
    public GameObject choiceButtonPrefab;

    public GameObject choicesPanel;

    public Chapter1 chapter;

    public void ShowLine(string character, string text)
    {
        if (nameText == null || dialogueText == null)
        {
            Debug.LogError("UI Text references not assigned!");
            return;
        }

        nameText.text = character;
        dialogueText.text = text;
    }

    public void ShowChoices(DialogueChoice[] choices)
    {
        Debug.Log("ShowChoices called");

        // ⭐ SHOW PANEL
        if (choicesPanel != null)
            choicesPanel.SetActive(true);

        foreach (Transform child in choicesParent)
            Destroy(child.gameObject);

        foreach (var choice in choices)
        {
            GameObject btn = Instantiate(choiceButtonPrefab, choicesParent);

            var text = btn.GetComponentInChildren<TMP_Text>();
            text.text = choice.choiceText;

            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (chapter == null)
                {
                    Debug.LogError("Chapter1 not assigned!");
                    return;
                }

                chapter.OnChoiceSelected(choice);
            });
        }
    }

    public void ClearChoices()
    {
        foreach (Transform child in choicesParent)
            Destroy(child.gameObject);

        // HIDE PANEL
        if (choicesPanel != null)
            choicesPanel.SetActive(false);
    }
}