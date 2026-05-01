using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UISound : MonoBehaviour
{
    private static bool alreadyHooked = false;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        HookButtonsDelayed();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        alreadyHooked = false; // allow re-hook on scene change
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HookButtonsDelayed();
    }

    void HookButtonsDelayed()
    {
        StopAllCoroutines();
        StartCoroutine(HookAfterFrame());
    }

    IEnumerator HookAfterFrame()
    {
        yield return null;
        yield return null; // wait 2 frames

        HookButtons();
    }

    void HookButtons()
    {
        if (alreadyHooked)
        {
            return;
        }

        Button[] buttons = FindObjectsByType<Button>(FindObjectsSortMode.None);

        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(PlayClickSound);
        }

        alreadyHooked = true;
        Debug.Log("UI Buttons hooked: " + buttons.Length);
    }

    void PlayClickSound()
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogWarning("AudioManager missing");
            return;
        }

        Debug.Log("Click triggered");

        AudioManager.Instance.PlayClick();
    }
}