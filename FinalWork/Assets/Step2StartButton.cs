using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step2StartButton : MonoBehaviour
{
    public GameObject step2StartPanel;
    public GameObject npcProgressTextObject;
    public GameObject npcProgressTextObject2;
    public PlayerControllerToggle controllerToggle;
    public GameObject[] exclamationMarks;

    public void LaunchStep2()
    {
        ScenarioProgressManager.instance.MarkStep1Completed();
        step2StartPanel.SetActive(false);

        if (controllerToggle != null)
            controllerToggle.EnableControls();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (npcProgressTextObject != null)
            npcProgressTextObject.SetActive(true);
            
        if (npcProgressTextObject2 != null)
            npcProgressTextObject2.SetActive(true);

        foreach (GameObject mark in exclamationMarks)
        {
            if (mark != null)
                mark.SetActive(true);
        }
    }
}


