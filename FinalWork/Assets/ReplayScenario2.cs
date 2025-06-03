using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayScenario2 : MonoBehaviour
{
    public void Replay()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
