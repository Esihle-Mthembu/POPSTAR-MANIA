using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningSceneController : MonoBehaviour
{
    [Header("Opening Scene")]
    public string nextSceneName = "Main Menu";

    //Enter button
    public void EnterGame ()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    //Exit button
    public void ExitGame ()
    {
        Debug.Log("Game is exiting");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
