using UnityEngine;
using TMPro;
using Fungus;

public class CheckFungusInputEnter : MonoBehaviour
{
    public TMP_InputField inputField;
    public StringVariable targetVariable;
    public Flowchart flowchart;
    public string nextBlockName = "StartCheck"; // le nom du bloc à lancer si bon input

    void Update()
    {
        if (inputField.isFocused && Input.GetKeyDown(KeyCode.Return))
        {
            if (targetVariable != null && inputField != null)
            {
                targetVariable.Value = inputField.text;

                if (targetVariable.Value == "112")
                {
                    flowchart.ExecuteBlock(nextBlockName);
                }
                else
                {
                    // Optionnel : tu peux afficher un message ou vider l'input
                    Debug.Log("Mauvais numéro.");
                }
            }
        }
    }
}
