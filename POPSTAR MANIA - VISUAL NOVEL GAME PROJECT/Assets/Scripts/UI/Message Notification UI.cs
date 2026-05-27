using UnityEngine;
using UnityEngine.SceneManagement;

public class MessageNotificationUI : MonoBehaviour
{
    public GameObject icon;

    void Update()
    {
        if (MessageManager.Instance == null) return;

        Debug.Log(MessageManager.Instance.hasNewMessage);

        icon.SetActive(MessageManager.Instance.hasNewMessage);
    }

    public void OpenMessages()
    {
        SceneManager.LoadScene("Main Menu");
    }
}