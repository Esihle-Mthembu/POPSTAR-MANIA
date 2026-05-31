using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused = false;

    void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        AudioListener.pause = true;

        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        AudioListener.pause = false;

        isPaused = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnDisable()
    {
        // Safety: restore normal game state if object is disabled
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
}