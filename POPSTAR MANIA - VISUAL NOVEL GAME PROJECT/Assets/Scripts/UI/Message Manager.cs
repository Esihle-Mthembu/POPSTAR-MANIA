using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance;

    [TextArea(3, 5)]
    public string currentMessage;

    public bool hasNewMessage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReceiveMessage(string message)
    {
        currentMessage = message;
        hasNewMessage = true;

        Debug.Log("NEW MESSAGE RECEIVED: " + message);
    }

    public void ClearMessage()
    {
        currentMessage = "";
        hasNewMessage = false;
    }
}