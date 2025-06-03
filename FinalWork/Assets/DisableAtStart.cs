using UnityEngine;

public class DisableAtStart : MonoBehaviour
{
    public PlayerControllerToggle controllerToggle;

    void Start()
{
    controllerToggle.DisableControls();

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}
}
