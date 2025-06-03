using UnityEngine;

public class WeedPanelCloser : MonoBehaviour
{
    public GameObject infoPanel;
    public PlayerControllerToggle playerController;

    public GameObject sachetModel;
    public GameObject sachetCamera;
    public GameObject sachetLight;

    public void ClosePanel()
    {
        infoPanel.SetActive(false);

        // Cache le modèle avec caméra et lumière
        if (sachetModel != null) sachetModel.SetActive(false);
        if (sachetCamera != null) sachetCamera.SetActive(false);
        if (sachetLight != null) sachetLight.SetActive(false);

        // Réactive les mouvements
        if (playerController != null)
            playerController.EnableControls();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
