using UnityEngine;
using TMPro;

public class MessagesApp : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI messageText;

    void Start()
    {
        panel.SetActive(false);

        if (MessageManager.Instance != null &&
            MessageManager.Instance.hasNewMessage)
        {
            OpenMessage();
        }
    }

    public void OpenMessage()
    {
        panel.SetActive(true);

        messageText.text = MessageManager.Instance.currentMessage;

        MessageManager.Instance.ClearMessage();
    }

    public void CloseMessage()
    {
        panel.SetActive(false);
    }
}