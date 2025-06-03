using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class StepOrderChecker : MonoBehaviour
{
    public Transform stepContainer;
    public string[] correctOrder;
    public Flowchart flowchart;
    public string successBlockName = "PLS1";

    public AudioSource wrongAnswerAudio; // Ajout ici

    public void CheckOrder()
    {
        bool correct = true;

        for (int i = 0; i < stepContainer.childCount; i++)
        {
            Transform step = stepContainer.GetChild(i);
            string currentName = step.name;

            Image image = step.GetComponentInChildren<Image>();
            if (image != null)
            {
                if (currentName == correctOrder[i])
                {
                    image.color = Color.green;
                }
                else
                {
                    image.color = Color.red;
                    correct = false;
                }
            }
        }

        if (correct && flowchart != null)
        {
            flowchart.ExecuteBlock(successBlockName);
        }
        else if (!correct && wrongAnswerAudio != null && !wrongAnswerAudio.isPlaying)
        {
            wrongAnswerAudio.Play();
        }
    }
}
