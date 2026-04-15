using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUIManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public GameObject choiceButtonPrefab;
    public Transform choicesContainer;

    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindFirstObjectByType<DialogueManager>();
    }

    public void ShowChoices(DialogueChoice[] choices)
    {
        ClearChoices();

        foreach (DialogueChoice choice in choices)
        {
            GameObject buttonObj = Instantiate(choiceButtonPrefab, choicesContainer);
            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();

            buttonText.text = choice.choiceText;

            Button btn = buttonObj.GetComponent<Button>();
            btn.onClick.AddListener(() => dialogueManager.OnChoiceSelected(choice));
        }
    }

    public void ClearChoices()
    {
        foreach (Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetName(string name)
    {
        nameText.text = name;
    }

    public void SetText(string text)
    {
        dialogueText.text = text;
    }

    public void AppendText(string text)
    {
        dialogueText.text += text;
    }
}