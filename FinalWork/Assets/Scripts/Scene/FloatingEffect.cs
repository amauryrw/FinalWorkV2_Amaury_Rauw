using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float floatStrength = 0.5f;     // Amplitude du flottement
    public float floatSpeed = 2f;          // Vitesse du flottement
    public float rotationSpeed = 30f;      // Optionnel : vitesse de rotation

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition; // Sauvegarde la position de départ
    }

    void Update()
    {
        // Mouvement haut-bas
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);

        // Optionnel : rotation autour de Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
