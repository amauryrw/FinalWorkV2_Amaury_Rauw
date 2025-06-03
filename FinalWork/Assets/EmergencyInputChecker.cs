using UnityEngine;
using TMPro;
using Fungus;

public class EmergencyInputChecker : MonoBehaviour
{
    public TMP_InputField inputField;
    public Flowchart flowchart;
    public string correctAnswer = "112";
    public string successBlockName = "Start112Call";
    public string errorBlockName = "WrongAnswerBlock";

    private void OnEnable()
    {
        if (inputField != null)
        {
            inputField.onSubmit.AddListener(CheckAnswer);
            inputField.text = ""; // Reset input
            inputField.ActivateInputField(); // Focus direct
        }
    }

    private void OnDisable()
    {
        if (inputField != null)
        {
            inputField.onSubmit.RemoveListener(CheckAnswer);
        }
    }

    private void CheckAnswer(string userInput)
    {
        if (userInput.Trim() == correctAnswer)
        {
            flowchart.ExecuteBlock(successBlockName);
        }
        else
        {
            flowchart.ExecuteBlock(errorBlockName);
        }
    }
}
