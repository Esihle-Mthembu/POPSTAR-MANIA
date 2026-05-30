using UnityEngine;

public class SunnyShader : MonoBehaviour
{
    public string CurrentShader => currentShader;
    public static SunnyShader Instance;

    [Header("Shader Objects")]
    public GameObject sunnyShader;

    private string currentShader = "";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayShader(string shaderName)
    {
        if (string.IsNullOrWhiteSpace(shaderName))
        // Ignore empty shader names
        if (string.IsNullOrWhiteSpace(shaderName))
            return;

        // Prevent replaying same shader
        if (currentShader == shaderName)
            return;

        // ALWAYS reset first
        DisableAllShaders();

        currentShader = shaderName;

        switch (shaderName)
        {
            case "Sunny":
                sunnyShader.SetActive(true);
                break;

            case "None":
                currentShader = "";
                break;
        }
    }

    void DisableAllShaders()
    {
        sunnyShader.SetActive(false);

    }
}
