using UnityEngine;

public class PlayerControllerToggle : MonoBehaviour
{
    public MonoBehaviour movementScript;
    public MouseLook cameraScript;

    public bool ControlsEnabled { get; private set; } = true;

    public void EnableControls()
    {
        if (movementScript != null) movementScript.enabled = true;
        if (cameraScript != null) cameraScript.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ControlsEnabled = true; 
    }

    public void DisableControls()
    {
        if (movementScript != null) movementScript.enabled = false;
        if (cameraScript != null) cameraScript.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ControlsEnabled = false;
    }
}
