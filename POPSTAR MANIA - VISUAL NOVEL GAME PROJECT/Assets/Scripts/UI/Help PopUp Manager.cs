using UnityEngine;
using TMPro;

public class HelpPopUpManager : MonoBehaviour
{
    public GameObject popup;
    public TextMeshProUGUI text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Show only at the beginning
        ShowHelp();
    }

    public void ShowHelp()
    {
        popup.SetActive(true);

        text.text =
        "CONTROLS:\n\n" +
        "SPACE KEY - Progress through dialogue\n\n\n" +
        "UI BUTTONS: \n" +
        "Rewind - Go back in dialogue\n" +
        "Auto - Progress through dialogue automatically\n" +
        "Skip - Fast forward dialogue\n\n\n" +
        "IMPORTANT:\n" +
        "DO NOT FORGET TO SAVE YOUR PROGRESS\n";
    }

    public void CloseHelp()
    {
        popup.SetActive(false);
    }
}
