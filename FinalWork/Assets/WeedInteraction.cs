using UnityEngine;

public class WeedTriggerZone : MonoBehaviour
{
    public GameObject interactionText;
    public GameObject infoPanel;
    public PlayerControllerToggle playerController;

    public GameObject sachetModel;
    public GameObject sachetCamera;
    public GameObject sachetLight;

    private bool playerInside = false;

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            // Active panel
            infoPanel.SetActive(true);
            interactionText.SetActive(false);

            // Affiche le modèle avec caméra et lumière
            if (sachetModel != null) sachetModel.SetActive(true);
            if (sachetCamera != null) sachetCamera.SetActive(true);
            if (sachetLight != null) sachetLight.SetActive(true);

            // Bloque les mouvements
            if (playerController != null)
                playerController.DisableControls();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.SetActive(true);
            playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.SetActive(false);
            playerInside = false;
        }
    }
}
