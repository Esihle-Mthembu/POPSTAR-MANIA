using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public AudioManager audioManagerPrefab;

    void Awake()
    {
        if (AudioManager.Instance == null)
        {
            Instantiate(audioManagerPrefab);
        }
    }
}
