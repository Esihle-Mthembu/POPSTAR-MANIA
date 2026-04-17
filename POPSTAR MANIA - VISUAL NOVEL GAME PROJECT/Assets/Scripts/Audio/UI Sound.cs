using UnityEngine;
using UnityEngine.EventSystems;

public class UISound : MonoBehaviour
{
    public void PlayClick()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.clickSound);
    }
}