using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private Transform lookTarget; // Le point précis que le joueur doit regarder
    [SerializeField] private float maxLookAngle = 15f;  // L'angle à partir duquel le joueur peut interagir
    [SerializeField] private float maxDistance = 10f;  // La distance minimale pour que la conversation démarre

    private Camera playerCamera;
    private bool conversationStarted = false; // Pour éviter de lancer la conversation plusieurs fois

    private void Start()
    {
        // Assure-toi que la caméra du joueur est bien récupérée
        playerCamera = Camera.main;
    }

    private void Update()
    {
        // Vérifie si le joueur regarde le point cible et si la distance est correcte
        Vector3 toTarget = lookTarget.position - playerCamera.transform.position;
        float angle = Vector3.Angle(playerCamera.transform.forward, toTarget); // Angle entre la direction de la caméra et la cible
        float distance = toTarget.magnitude;

        // Si l'angle est assez petit et que la distance est suffisante et que la conversation n'a pas encore commencé
        if (angle < maxLookAngle && distance < maxDistance && !conversationStarted)
        {
            // Démarre la conversation automatiquement
            conversationStarted = true;  // Marque la conversation comme lancée pour ne pas la redémarrer continuellement
        }

        // Si le joueur ne regarde plus l'NPC, réinitialise la variable pour permettre une nouvelle interaction plus tard
        if (angle >= maxLookAngle || distance >= maxDistance)
        {
            conversationStarted = false;  // Permet de redémarrer la conversation si le joueur revient et regarde à nouveau
        }
    }
}
