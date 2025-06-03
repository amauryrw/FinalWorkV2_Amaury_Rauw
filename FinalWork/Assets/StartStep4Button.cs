using UnityEngine;
using Fungus;

public class StartStep4Button : MonoBehaviour
{
    public GameObject panelStep4;
    public PlayerControllerToggle controllerToggle;

    public Flowchart flowchart;                
    public string blockName = "IntroStep4";    

    public void LaunchStep4()
    {
        if (panelStep4 != null)
            panelStep4.SetActive(false);

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
