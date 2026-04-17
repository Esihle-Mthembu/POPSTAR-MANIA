using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Continue button
    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("LastScene"))
        {
            string sceneName = PlayerPrefs.GetString("LastScene");

            SceneManager.LoadScene("In-Game UI scene");
        }
        else
        {
            Debug.Log("No saved game found");
        }
    }

    // New Game button
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("DialogueIndex");

        PlayerPrefs.SetString("StartDialogue", "Prologue");

        SceneManager.LoadScene("In-Game UI scene");
    }

    // Settings button
    public void Settings()
    {
        if (SettingsMenu.Instance != null)
        {
            SettingsMenu.Instance.OpenSettings();
        }
        else
        {
            Debug.LogWarning("SettingsMenu not found in scene!");
        }
    }

    // Exit button
    public void QuitGame()
    {
        Debug.Log("Quit Game triggered");
        Application.Quit();
    }
}