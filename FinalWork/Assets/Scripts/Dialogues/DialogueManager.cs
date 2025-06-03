
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;


/*public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // Le texte du dialogue
    public Button[] choiceButtons; // Les boutons de choix
    public Color greenColor; // La couleur verte pour l'écran
    public Color redColor; // La couleur rouge pour l'écran

    private Story currentStory; // L'histoire en cours

    void Start()
    {
        // Charger le script Ink
        TextAsset inkJSON = Resources.Load<TextAsset>("Dialogues"); // Assure-toi d’avoir placé ton fichier .ink compilé dans le dossier Resources
        currentStory = new Story(inkJSON.text);

        DisplayNextLine();
    }

    void DisplayNextLine()
    {
        // Afficher le texte
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }

        // Afficher les choix
        if (currentStory.hasChoices)
        {
            for (int i = 0; i < currentStory.currentChoices.Count; i++)
            {
                choiceButtons[i].gameObject.SetActive(true);
                choiceButtons[i].GetComponentInChildren<Text>().text = currentStory.currentChoices[i].text;
                int index = i;
                choiceButtons[i].onClick.AddListener(() => MakeChoice(index));
            }
        }
    }

    void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        DisplayNextLine();
    }
}**/
