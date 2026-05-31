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

        if (string.IsNullOrEmpty(shaderName) || shaderName != "Sunny")
        {
            ForceOff();
            return;
        }

        sunnyShader.SetActive(true);
    }

    public void ForceOff()
    {
        if (sunnyShader == null)
            return;

        sunnyShader.SetActive(false);
    }
}