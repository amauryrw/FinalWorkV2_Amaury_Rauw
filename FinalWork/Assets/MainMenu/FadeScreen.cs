using System.Collections;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject fadeObject;
    public float fadeDuration = 1f;

    public void FadeOut(System.Action onComplete)
    {
        fadeObject.SetActive(true);
        StartCoroutine(Fade(0, 1, onComplete));
    }

    private IEnumerator Fade(float start, float end, System.Action onComplete)
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, t / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = end;
        onComplete?.Invoke();
    }
}
