using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UISound : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        HookButtonsDelayed();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
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
        Button[] buttons = FindObjectsByType<Button>(FindObjectsSortMode.None);
        int hooked = 0;

        foreach (Button btn in buttons)
        {
            // remove any previous binding to avoid duplicates, then add
            btn.onClick.RemoveListener(PlayClickSound);
            btn.onClick.AddListener(PlayClickSound);
            hooked++;
        }

        Debug.Log("UI Buttons hooked: " + hooked);
    }

    void PlayClickSound()
    {
        // Prefer MusicManager if present
        if (MusicManager.Instance != null && MusicManager.Instance.clickSound != null)
        {
            MusicManager.Instance.PlayClick();
            return;
        }


        Debug.LogWarning("No audio manager available for UI click.");
    }
}