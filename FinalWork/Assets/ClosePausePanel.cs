using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePausePanel : MonoBehaviour
{
    public GameObject panelToClose;
    public PlayerControllerToggle controllerToggle;

    public void ClosePanel()
    {
        if (panelToClose != null)
            panelToClose.SetActive(false);

        if (controllerToggle != null)
            controllerToggle.EnableControls();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
