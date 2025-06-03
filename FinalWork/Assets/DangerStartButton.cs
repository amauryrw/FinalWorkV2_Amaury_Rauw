using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class DangerStartButton : MonoBehaviour
{
    public GameObject panelUI;
    public PlayerControllerToggle controllerToggle;

    public GameObject ProgressText;

    public void StartDangerMission()
    {
        panelUI.SetActive(false);
        controllerToggle.EnableControls();

        ProgressText.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
