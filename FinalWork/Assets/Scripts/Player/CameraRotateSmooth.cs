using UnityEngine;

public class CameraRotateSmooth : MonoBehaviour
{
    public Transform startView;
    public Transform playerView;
    public float moveSpeed = 2f;
    public float rotateSpeed = 2f;

    private bool movingToPlayer = false;

    void Update()
    {
        if (movingToPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, playerView.position, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerView.rotation, Time.deltaTime * rotateSpeed);
        }
    }

    public void StartMoveToPlayer()
    {
        movingToPlayer = true;
    }
}
