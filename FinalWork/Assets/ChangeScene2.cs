using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene2 : MonoBehaviour
{
    public string sceneName;

    public void StartFadeThenScene()
    {

        SceneManager.LoadScene(sceneName);
    }
}
