using UnityEngine;
using TMPro;

public class MessagesApp : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI messageText;

    void Start()
    {
        panel.SetActive(false);

        if (MessageManager.Instance != null && MessageManager.Instance.hasNewMessage)
        {
            OpenMessage();
        }
    }

    public void OpenMessage()
    {
        Debug.Log("MESSAGE BUTTON CLICKED");

        panel.SetActive(true);

        messageText.text = MessageManager.Instance.currentMessage;
    }

    public void CloseMessage()
    {
        panel.SetActive(false);
    }
}