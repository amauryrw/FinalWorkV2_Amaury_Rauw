using UnityEngine;

public class StartStep3Button : MonoBehaviour
{
    public GameObject instructionText; 
    public GameObject step3StartPanel;
    public PlayerControllerToggle controllerToggle;

    public void LaunchStep3()
    {
        if (step3StartPanel != null)
            step3StartPanel.SetActive(false);

        ScenarioProgressManager.instance.MarkStep2Completed();

        if (controllerToggle != null)
            controllerToggle.DisableControls();

        // ✅ Affiche la souris
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // ✅ Active le texte d’instruction
        if (instructionText != null)
            instructionText.SetActive(true);
    }
}
