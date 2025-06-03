using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public string sceneName;

    public void StartFadeThenScene()
    {
        fadeScreen.FadeOut(() => SceneManager.LoadScene(sceneName));
    }
}
