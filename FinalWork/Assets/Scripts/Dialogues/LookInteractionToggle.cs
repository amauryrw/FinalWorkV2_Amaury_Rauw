using UnityEngine;

public class LookInteractionToggle : MonoBehaviour
{
    public GameObject bubbleCanvas;           // La bulle de texte
    public GameObject exclamationMark;        // Le point d’interrogation
    public Transform playerCamera;            // La caméra du joueur
    public float maxViewAngle = 30f;          // Angle de vision pour détecter

    void Update()
    {
        Vector3 directionToCamera = (playerCamera.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, directionToCamera);

        bool isLooking = angle < maxViewAngle;

        bubbleCanvas.SetActive(isLooking);
        exclamationMark.SetActive(!isLooking);
    }
}
