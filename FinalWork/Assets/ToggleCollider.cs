using UnityEngine;

public class ToggleCollider : MonoBehaviour
{
    public BoxCollider targetCollider;

    public void EnableCollider()
    {
        if (targetCollider != null)
        {
            targetCollider.enabled = true;
        }
    }

    public void DisableCollider()
    {
        if (targetCollider != null)
        {
            targetCollider.enabled = false;
        }
    }
}
