using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("LastScene"))
        {
            string sceneName = PlayerPrefs.GetString("LastScene");
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("No saved game found");
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteKey("DialogueIndex");

        PlayerPrefs.SetString("LastScene", "Prologue");
        SceneManager.LoadScene("Prologue");
    }

    public void Settings()
    {
        Debug.Log("Open Settings Menu");
    }

    public void Exit()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}