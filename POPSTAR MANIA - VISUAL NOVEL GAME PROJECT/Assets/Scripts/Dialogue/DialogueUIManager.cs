using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUIManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image backgroundImage;
    public Image characterImage;

    public GameObject choicePanel;
    public GameObject choiceButtonPrefab;
    public Transform choicesContainer;

    private DialogueManager dialogueManager;

    void Awake()
    {
        if (choicePanel != null)
            choicePanel.SetActive(false);
    }

    void Start()
    {
        dialogueManager = FindFirstObjectByType<DialogueManager>();
    }

    public void ShowChoices(DialogueChoice[] choices)
    {
        ClearChoices();

        if (choicePanel != null)
            choicePanel.SetActive(true);

        foreach (DialogueChoice choice in choices)
        {
            GameObject buttonObj = Instantiate(choiceButtonPrefab, choicesContainer);

            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = choice.choiceText;

            Button btn = buttonObj.GetComponent<Button>();

            DialogueChoice capturedChoice = choice;

            btn.onClick.AddListener(() =>
            {
                dialogueManager.SelectChoice(capturedChoice);
            });
        }
    }

    public void ClearChoices()
    {
        foreach (Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }

        if (choicePanel != null)
            choicePanel.SetActive(false);
    }

    public void SetLine(DialogueLine line)
    {
        nameText.text = line.speakerName;
        dialogueText.text = line.dialogueText;

        characterImage.sprite = line.characterSprite;

        if (line.background != null)
            backgroundImage.sprite = line.background;
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