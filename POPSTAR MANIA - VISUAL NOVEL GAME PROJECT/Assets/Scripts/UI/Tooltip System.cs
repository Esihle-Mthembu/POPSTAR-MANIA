using UnityEngine;
using TMPro;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem Instance;

    public GameObject tooltipPanel;
    public TextMeshProUGUI tooltipText;

    private void Awake()
    {
        //Prevent duplicates
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Hide();
    }

    // Update is called once per frame
    private void Update()
    {
        if (tooltipPanel == null)
        {
            return;
        }

        //Make tooltip follow mouse
        Vector2 mousePos = Input.mousePosition;
        tooltipPanel.transform.position = mousePos + new Vector2(15, -15);
    }

    public void Show(string message)
    {
        if (tooltipPanel == null || tooltipText == null)
        {
            return;
        }

        tooltipPanel.SetActive(true);
        tooltipText.text = message;
    }

    public void Hide()
    {
        if (tooltipPanel == null)
        {
            return;
        }

        tooltipPanel.SetActive(false);
    }
}
