using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StapStep5Button : MonoBehaviour
{
   public GameObject panelStep5;
    public PlayerControllerToggle controllerToggle;

    public Flowchart flowchart;                
    public string blockName = "Step5";    

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
