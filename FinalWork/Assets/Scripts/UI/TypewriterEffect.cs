using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    public float typingSpeed = 50f;
    private TextMeshProUGUI textMesh;
    private string fullText = "";

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        fullText = textMesh.text; // 🔥 On prend le texte déjà écrit dans l'éditeur
    }

    private void OnEnable()
    {
        if (textMesh != null)
        {
            StopAllCoroutines();
            StartCoroutine(TypeText());
        }
    }

    IEnumerator TypeText()
    {
        textMesh.text = "";
        foreach (char c in fullText)
        {
            textMesh.text += c;
            yield return new WaitForSeconds(1f / typingSpeed);
        }
    }
}
