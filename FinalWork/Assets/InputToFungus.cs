using UnityEngine;
using TMPro;
using Fungus;

public class InputToFungus : MonoBehaviour
{
    public TMP_InputField inputField;
    public Flowchart flowchart;
    public string fungusVariableName = "userInput";

    public void SubmitInput()
    {
        if (inputField != null && flowchart != null)
        {
            flowchart.SetStringVariable(fungusVariableName, inputField.text);
        }
    }
}
