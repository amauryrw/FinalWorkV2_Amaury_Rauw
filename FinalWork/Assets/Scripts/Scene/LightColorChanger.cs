using UnityEngine;

public class LightColorChanger : MonoBehaviour
{
    public Light discoLight;
    public float changeInterval = 2f; // Temps pour changer vers la nouvelle couleur
    public float transitionSpeed = 2f; // Vitesse de transition (plus grand = plus rapide)

    private Color[] discoColors = new Color[]
    {
        Color.red,
        Color.blue,
        Color.magenta,
        Color.cyan,
        Color.green,
        Color.yellow,
        new Color(1f, 0.5f, 0f), // Orange
        new Color(0.5f, 0f, 1f)  // Violet flashy
    };

    private Color targetColor;
    private float timer = 0f;

    void Start()
    {
        if (discoLight != null)
            targetColor = discoLight.color;
    }

    void Update()
    {
        if (discoLight == null)
            return;

        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            targetColor = discoColors[Random.Range(0, discoColors.Length)];
            timer = 0f;
        }

        // Transition douce vers la nouvelle couleur
        discoLight.color = Color.Lerp(discoLight.color, targetColor, Time.deltaTime * transitionSpeed);
    }
}
