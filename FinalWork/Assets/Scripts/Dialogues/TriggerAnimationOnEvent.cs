using UnityEngine;

public class TriggerAnimationOnEvent : MonoBehaviour
{
    private Animator animator; // Référence à l'Animator

    void Start()
    {
        // Récupère l'Animator attaché à cet objet
        animator = GetComponent<Animator>();
    }

    // Cette méthode est appelée pour activer l'animation via le Trigger
    public void PlayAnimation(string triggerName)
    {
        if (animator != null)
        {
            animator.SetTrigger(triggerName); // Active le Trigger dans l'Animator
        }
    }
}
