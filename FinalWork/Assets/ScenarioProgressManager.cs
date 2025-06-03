using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScenarioProgressManager : MonoBehaviour
{
    public static ScenarioProgressManager instance;
    public TextMeshProUGUI npcProgressText;
    public TextMeshProUGUI npcProgressText2;
    public bool step1Completed = false;
    public int npcInteractedCount = 0;
    public int npcRequired = 3;
    public GameObject step2CompletePanel;
    public bool step2Completed = false;
    public GameObject step3StartPanel;
    public PlayerControllerToggle controllerToggle;

    void Awake()
    {
        instance = this;
        UpdateProgressUI();

    }

    public void MarkStep1Completed()
    {
        step1Completed = true;
    }
    public void MarkStep2Completed()
{
    step2Completed = true;
}

    public void NPCInteracted()
    {
        npcInteractedCount++;
        UpdateProgressUI();


        if (npcInteractedCount >= npcRequired)
        {
            if (npcProgressText != null)
                npcProgressText.gameObject.SetActive(false);
            if (npcProgressText2 != null)
                npcProgressText2.gameObject.SetActive(false);

            if (step2CompletePanel != null)
                step2CompletePanel.SetActive(true);

            if (step3StartPanel != null)
                step3StartPanel.SetActive(true);

            if (controllerToggle != null)
                controllerToggle.DisableControls();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    void UpdateProgressUI()
    {
        
        if (npcProgressText != null)
        {
            npcProgressText.text = "Personen ondervraagd : " + npcInteractedCount + " / " + npcRequired;
        }
    }
}
