using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public Button retryButton;
    public Button unlockButton;

    private void Start()
    {
        resultPanel.SetActive(false); // Panel caché au début
    }

    public void ShowResult()
    {
        resultPanel.SetActive(true);

        int badAnswers = ScoreManager.instance.GetBadResponse();

        if (badAnswers > 1)
        {
            resultText.text = "Je hebt " + badAnswers + " foute keuzes gemaakt.\n Om het volgende scenario te ontgrendelen, mag je maximaal één fout maken!";
            retryButton.gameObject.SetActive(true);
            unlockButton.gameObject.SetActive(false);
        }
        else
        {
            resultText.text = "Proficiat! Je bent geslaagd met " + badAnswers + " foute keuzes!";
            retryButton.gameObject.SetActive(false);
            unlockButton.gameObject.SetActive(true);
        }
    }

    public void RetryScenario()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UnlockNextScenario()
    {
        Debug.Log("Next scenario unlocked !");
        SceneManager.LoadScene("Scenario2"); // Remplace "Scenario2" par le vrai nom exact de ta scène
    }
}
