using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public void StartGameButton()
    {
        SceneManager.LoadScene("Opening");
    }

    void Start()
    {
        dialogueManager.StartDialogue(dialogueManager.prologueDialogue);
    }
}