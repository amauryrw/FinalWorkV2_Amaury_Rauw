using UnityEngine;
using System.Collections;

public class Step5ImageManager : MonoBehaviour
{
    public GameObject[] images; 
    public float delayBetween = 0.5f;

    void Start()
    {
        foreach (var img in images)
            img.SetActive(false);
    }

    public void ShowImagesOneByOne()
    {
        StartCoroutine(ShowRoutine());
    }

    IEnumerator ShowRoutine()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(true);
            yield return new WaitForSeconds(delayBetween);
        }
    }
}
