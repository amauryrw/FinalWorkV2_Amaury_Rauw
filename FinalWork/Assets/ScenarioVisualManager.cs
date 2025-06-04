using UnityEngine;

public class ScenarioVisualManager : MonoBehaviour
{
    public GameObject scenario2Unlocked;
    public GameObject scenario2Locked;

    
    void Start()
    {
        if (!PlayerPrefs.HasKey("Scenario1Completed"))
        {
            PlayerPrefs.SetInt("Scenario1Completed", 0);
            PlayerPrefs.Save();
        }

        int completed = PlayerPrefs.GetInt("Scenario1Completed");

        bool unlocked = (completed == 1);

        scenario2Unlocked.SetActive(unlocked);
        scenario2Locked.SetActive(!unlocked);
    }
}
