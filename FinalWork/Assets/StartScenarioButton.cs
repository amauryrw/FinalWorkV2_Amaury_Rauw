using UnityEngine;
using Fungus;

public class StartScenarioButton : MonoBehaviour
{
    public GameObject startPanel;
    public Flowchart flowchart;
    public string blockName = "IntroScenario2";

    public void StartScenario()
    {
        if (startPanel != null)
            startPanel.SetActive(false); // Cache le menu

        if (flowchart != null)
            flowchart.ExecuteBlock(blockName); // Lance le bloc Fungus
        
    }
    
}
