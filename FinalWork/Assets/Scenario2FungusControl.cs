using UnityEngine;

public class Scenario2FungusControl : MonoBehaviour
{
    public GameObject fungusTriggerObject; // Le GameObject contenant le script FungusTrigger
    public GameObject interactionUI; // Le texte "Press E" ou "Interaction"

    private FungusTrigger fungusTrigger;

    void Start()
    {
        if (fungusTriggerObject != null)
        {
            fungusTrigger = fungusTriggerObject.GetComponent<FungusTrigger>();

            if (fungusTrigger != null)
            {
                fungusTrigger.enabled = false; // On désactive le comportement
            }
        }

        if (interactionUI != null)
        {
            interactionUI.SetActive(false); // Cache le texte si visible
        }
    }

    public void ReactivateFungusTrigger()
    {
        if (interactionUI != null)
        interactionUI.SetActive(true); // Affiche le texte

        if (fungusTrigger != null)
            fungusTrigger.enabled = true; // Réactive le comportement d’interaction
        }
}
