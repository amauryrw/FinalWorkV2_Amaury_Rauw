using UnityEngine;
using TMPro;

public class LookAtTrigger : MonoBehaviour
{
    public Transform playerCamera; // Caméra principale
    public GameObject dialogueUI;  // Texte à activer
    public float triggerAngle = 20f;

    private bool hasSpoken = false;

    void Update()
    {
        Vector3 toCharacter = (transform.position - playerCamera.position).normalized;
        float angle = Vector3.Angle(playerCamera.forward, toCharacter);

        if (angle < triggerAngle && !hasSpoken)
        {
            dialogueUI.SetActive(true);
            hasSpoken = true;
        }
    }
}
