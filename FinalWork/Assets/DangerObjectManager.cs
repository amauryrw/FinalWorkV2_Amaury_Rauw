using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DangerObjectManager : MonoBehaviour
{
    public GameObject timeoutPanel;
    public TextMeshProUGUI progressText;
    public Image timerBar;

    public Image timerBarBack;
    public int totalToFind = 2;
    private int found = 0;

    public float timeLimit = 30f;
    private float timer;
    private bool timerRunning = false;

    public PlayerControllerToggle controllerToggle;
    public GameObject finishPanel;

    void Start()
    {
        timer = timeLimit;

        if (timerBar != null)
        {
            timerBar.fillAmount = 1f;
            timerBar.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (timerRunning)
        {
            timer -= Time.deltaTime;

            if (timerBar != null)
            {
                float progress = Mathf.Clamp01(timer / timeLimit);
                timerBar.fillAmount = progress;

                // Changer la couleur quand il reste moins de 10 sec
                timerBar.color = (timer <= 10f) ? Color.red : Color.white;
            }

            if (timer <= 0f)
            {
                RestartScenario();
            }
        }
    }

    public void StartTimer()
    {
        timer = timeLimit;
        timerRunning = true;

        if (timerBar != null)
            timerBar.gameObject.SetActive(true);

        if (progressText != null)
        {
            progressText.text = "0 op " + totalToFind + " gevonden";
            progressText.gameObject.SetActive(true);

            if (progressText.transform.parent != null)
                progressText.transform.parent.gameObject.SetActive(true);
        }
    }

    public void StopTimer()
    {
        timerRunning = false;

        if (timerBar != null)
            timerBar.gameObject.SetActive(false);
            
        if (timerBarBack != null)
        timerBarBack.gameObject.SetActive(false);

        if (progressText != null)
        {
            progressText.gameObject.SetActive(false);

            if (progressText.transform.parent != null)
                progressText.transform.parent.gameObject.SetActive(false);
        }
    }

    private void RestartScenario()
    {
        timerRunning = false;

        controllerToggle.DisableControls();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (timeoutPanel != null)
            timeoutPanel.SetActive(true);
    }

    public void ObjectFound()
    {
        found++;

        if (progressText != null)
        {
            progressText.text = found + " op " + totalToFind + " gevonden";
        }

        if (found >= totalToFind)
        {
            if (progressText != null)
                progressText.gameObject.SetActive(false);

            StopTimer();

            if (finishPanel != null)
                finishPanel.SetActive(true);

            controllerToggle.DisableControls();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void RetryScenario()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
