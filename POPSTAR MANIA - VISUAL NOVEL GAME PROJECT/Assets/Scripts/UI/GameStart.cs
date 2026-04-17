using UnityEngine;

public class GameStart : MonoBehaviour
{
    public DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager.StartGame();
    }
}