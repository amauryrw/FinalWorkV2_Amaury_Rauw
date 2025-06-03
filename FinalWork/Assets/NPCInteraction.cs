using UnityEngine;
using Fungus;

public class NPCInteraction : MonoBehaviour
{
    public GameObject pressEMessage;
    public Flowchart flowchart;
    public string blockName;
    public GameObject exclamationMark;


    private bool playerNearby = false;
    private bool hasInteracted = false;
    void Start()
    {
        if (ScenarioProgressManager.instance.step1Completed && !hasInteracted && exclamationMark != null)
        {
            exclamationMark.SetActive(true);
        }
    }
    void Update()
    {
        if (playerNearby && !hasInteracted && ScenarioProgressManager.instance.step1Completed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressEMessage.SetActive(false);
                hasInteracted = true;
                if (exclamationMark != null)
                    exclamationMark.SetActive(false);

                if (flowchart != null)
                    flowchart.ExecuteBlock(blockName);
                if (exclamationMark != null)
                    exclamationMark.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ScenarioProgressManager.instance.step1Completed && !hasInteracted)
        {
            pressEMessage.SetActive(true);
            playerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressEMessage.SetActive(false);
            playerNearby = false;
        }
    }
}
