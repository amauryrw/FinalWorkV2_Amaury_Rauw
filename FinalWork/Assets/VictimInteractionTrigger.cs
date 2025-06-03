using UnityEngine;

public class VictimInteractionTrigger : MonoBehaviour
{
    public GameObject pressEUI;                    // "Press E to interact"
    public GameObject instructionPanel;            // Panel met uitleg
    public Transform cameraTarget;                 // Positie boven het slachtoffer
    public GameObject playerCamera;                // De Main Camera
    public PlayerControllerToggle controllerToggle;// Voor bewegen/mouselook uit

    private bool isPlayerNearby = false;
    private bool hasInteracted = false;

    void Update()
    {
        if (isPlayerNearby && !hasInteracted && Input.GetKeyDown(KeyCode.E))
        {
            // 1. Verberg "Press E"
            if (pressEUI != null)
                pressEUI.SetActive(false);

            hasInteracted = true;

            // 2. Verplaats camera boven slachtoffer
            if (playerCamera != null && cameraTarget != null)
            {
                playerCamera.transform.position = cameraTarget.position;
                playerCamera.transform.rotation = cameraTarget.rotation;
            }

            // 3. Beweging + camera blokkeren
            if (controllerToggle != null)
                controllerToggle.DisableControls();

            // 4. Cursor tonen
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // 5. Panel met instructie tonen
            if (instructionPanel != null)
                instructionPanel.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") &&
            ScenarioProgressManager.instance.step1Completed &&
            ScenarioProgressManager.instance.step2Completed &&
            !hasInteracted)
        {
            isPlayerNearby = true;

            if (pressEUI != null)
                pressEUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            if (pressEUI != null)
                pressEUI.SetActive(false);
        }
    }
}
