using UnityEngine;

public class NPCLookAtPlayer : MonoBehaviour
{
    public Transform head; // Assign the head bone or a transform that represents the head
    public Transform player; // Référence au joueur
    public float rotationSpeed = 5f; // Vitesse de rotation

    private bool shouldLookAtPlayer = false;

    void Update()
    {
        // Vérifie si le NPC doit regarder le joueur
        if (shouldLookAtPlayer && player != null)
        {
            // Calculer la direction vers le joueur, mais ignorer l'axe Y pour garder la tête horizontale
            Vector3 direction = (player.position - head.position).normalized;
            direction.y = 0; // Ignorer l'axe Y pour que la tête ne regarde pas vers le haut ou le bas
            Quaternion lookRotation = Quaternion.LookRotation(direction); // Créer la rotation vers le joueur

            // Appliquer la rotation manuellement à la tête du NPC
            head.rotation = Quaternion.Slerp(head.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }

    public void StartInteraction(Transform playerTransform)
    {
        // Lorsque l'interaction commence, activer le regard vers le joueur
        shouldLookAtPlayer = true;
        player = playerTransform;
    }

    public void StopInteraction()
    {
        // Lorsque l'interaction se termine, désactiver le regard vers le joueur
        shouldLookAtPlayer = false;
    }
}
