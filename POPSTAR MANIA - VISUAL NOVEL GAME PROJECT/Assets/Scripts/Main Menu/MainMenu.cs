using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Continue button
    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("SceneName"))
        {
            string sceneName = PlayerPrefs.GetString("SceneName");
            Debug.Log("Loading scene:" + sceneName);

            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("No saved game exists");
        }
    }

    // New Game button
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
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
            Debug.LogWarning("SettingsMenu not found in scene");
        }
    }

    // Exit button
    public void QuitGame()
    {
        Application.Quit();
    }
}