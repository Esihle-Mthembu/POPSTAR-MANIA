using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUIManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image backgroundImage;
    public Image centerCharacterImage;
    public Image leftCharacterImage;

    public GameObject choicePanel;
    public GameObject choiceButtonPrefab;
    public Transform choicesContainer;

    [SerializeField] private DialogueManager dialogueManager;

    void Awake()
    {
        if (choicePanel != null)
        {
            choicePanel.SetActive(false);
        }

        if (dialogueManager == null)
        {
            dialogueManager = FindFirstObjectByType<DialogueManager>();
        }
    }

    public void ShowChoices(DialogueChoice[] choices)
    {
        ClearChoices();

        if (choicePanel != null)
        {
            choicePanel.SetActive(true);
        }

        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager is missing in DialogueUIManager");
            return;
        }

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
            } );  
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
}