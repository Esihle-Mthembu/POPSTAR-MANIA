using UnityEngine;
using TMPro;

public class InstructionManager : MonoBehaviour
{
    public GameObject instructionUI;

    public bool canContinue = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instructionUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (canContinue && Input.GetKeyDown(KeyCode.Space))
        {
            Continue();
        }
    }

    void Continue()
    {
        canContinue = false;

        //Hide the instruction
        instructionUI.SetActive(false);

        Debug.Log("Player continued prologue");
    }
}
