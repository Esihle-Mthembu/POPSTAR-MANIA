using UnityEngine;

public class SunnyShader : MonoBehaviour
{
    public static SunnyShader Instance;

    [SerializeField] private GameObject sunnyShader;

    private void Awake()
    {
        // Singleton (scene-only, not persistent)
        Instance = this;

        // Always start clean per scene
        ForceOff();
    }

    private void Start()
    {
        ForceOff(); // extra safety for scene load timing
    }

    public void PlayShader(string shaderName)
    {
        if (sunnyShader == null)
            return;

        if (shaderName == "Sunny")
        {
            sunnyShader.SetActive(true);
        }
        else
        {
            ForceOff();
        }
    }

    public void ForceOff()
    {
        if (sunnyShader == null)
            return;

        sunnyShader.SetActive(false);
    }
}