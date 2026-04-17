using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Continue button
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

    //New Game button
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("DialogueIndex");

        PlayerPrefs.SetString("LastScene", "Prologue");
        SceneManager.LoadScene("Prologue scene");
    }

    //Settings button
    public void Settings()
    {
        Debug.Log("Open Settings Menu");
    }

    //Exit button
    public void QuitGame()
    {
        Debug.Log("Quit Game triggered");
        Application.Quit();
    }
}