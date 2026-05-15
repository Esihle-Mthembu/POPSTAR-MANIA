using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    // Continue button
    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("SceneName"))
        {
            string sceneName = PlayerPrefs.GetString("SceneName");
            Debug.Log("Loading scene:" + sceneName);

            // Play click (prefer AudioManager -> MusicManager delegation)
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayClick();
                StartCoroutine(LoadSceneDelayed(sceneName, 0.1f)); // smsall delay to start sound
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            Debug.Log("No saved game exists");
        }
    }

    private IEnumerator LoadSceneDelayed(string sceneName, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(sceneName);
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
            Debug.LogError("SettingsMenu.Instance is null, not initialized yet");
        }
    }

    // Exit button
    public void QuitGame()
    {
        Application.Quit();
    }
}