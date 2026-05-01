using UnityEngine;
using UnityEngine.EventSystems;

public class UISound : MonoBehaviour
{
    public void PlayClick()
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogError("AudioManager missing in this scene");
            return;
        }

        if (AudioManager.Instance.clickSound == null)
        {
            Debug.LogError("Click sound is not assigned");
            return;
        }

        AudioManager.Instance.PlaySFX(AudioManager.Instance.clickSound);
    }
}