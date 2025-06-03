using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;

    private Quaternion originalRotation;

    void Start()
    {
        // Sauvegarde de la rotation au démarrage
        originalRotation = transform.rotation;
    }

    public void FacePlayer()
    {
        if (player == null)
        {
            Debug.LogWarning("Aucun joueur assigné.");
            return;
        }

        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0f; // Garde la rotation horizontale seulement

        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);
    }

    public void ResetRotation()
    {
        transform.rotation = originalRotation;
    }
}
