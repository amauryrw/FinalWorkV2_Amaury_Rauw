using UnityEngine;

public class FloatingMarker : MonoBehaviour
{
    public Transform target;  
    public Vector3 offset = new Vector3(0, 2.2f, 0); 

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
