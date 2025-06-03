using UnityEngine;
using TMPro;

public class Chronometer : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private float elapsedTime = 0f;
    private bool isRunning = false;

    void OnEnable()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    void OnDisable()
    {
        isRunning = false;
    }

    void Update()
    {
        if (!isRunning) return;

        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
