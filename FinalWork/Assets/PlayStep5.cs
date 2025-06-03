using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayStep5 : MonoBehaviour
{
   public GameObject panelStep5;
    public PlayerControllerToggle controllerToggle;

    public Flowchart flowchart;                
    public string blockName = "PLS";    

    public void LaunchStep5()
    {
        if (panelStep5 != null)
            panelStep5.SetActive(false);

        if (controllerToggle != null)
            controllerToggle.DisableControls();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (flowchart != null)
        {
            flowchart.ExecuteBlock(blockName);
        }
    }
}
