using UnityEngine;

public class EnablePlayerControls : MonoBehaviour
{
    public GameObject panelToHide;
    public PlayerControllerToggle controllerToggle;

    public void EnableControls()
    {
        if (panelToHide != null)
            panelToHide.SetActive(false);

        // ✅ Marquer l’étape 2 comme terminée AVANT d’entrer dans la zone
        ScenarioProgressManager.instance.MarkStep2Completed();

        if (controllerToggle != null)
            controllerToggle.EnableControls();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
