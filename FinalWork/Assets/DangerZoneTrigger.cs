using UnityEngine;

public class DangerZoneTrigger : MonoBehaviour
{
    public GameObject panelUI;
    public PlayerControllerToggle controllerToggle;

    private bool alreadyTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyTriggered) return;

        if (other.CompareTag("Player"))
        {
            alreadyTriggered = true;

            controllerToggle.DisableControls();
            panelUI.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

