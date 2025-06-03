using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject pressEMessage;
    public DangerObjectManager manager;
    private bool canPickUp = false;

    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            pressEMessage.SetActive(false);
            if (manager != null)
            {
                manager.ObjectFound(); // compte 1 danger trouvé
            }

            gameObject.SetActive(false); // fait disparaître l’objet
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true;
            if (pressEMessage != null) pressEMessage.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = false;
            if (pressEMessage != null) pressEMessage.SetActive(false);
        }
    }
}
