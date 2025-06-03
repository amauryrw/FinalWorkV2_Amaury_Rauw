using UnityEngine;

public class LookAtDetector : MonoBehaviour
{
    public Transform playerCamera; // XR camera (center eye)
    public Transform lookTarget;   // GameObject vide au-dessus du perso
    public Canvas exclamationCanvas;
    public Canvas dialogueCanvas;

    public float maxLookAngle = 15f; // à ajuster si nécessaire
    public float maxDistance = 10f;

    void Update()
{
    Vector3 toTarget = lookTarget.position - playerCamera.position;
    float angle = Vector3.Angle(playerCamera.forward, toTarget);

    if (angle < maxLookAngle && toTarget.magnitude < maxDistance)
    {
        exclamationCanvas.enabled = false;
        dialogueCanvas.enabled = true;
    }
    else
    {
        exclamationCanvas.enabled = true;
        dialogueCanvas.enabled = false;
    }
}
}
