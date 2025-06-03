using UnityEngine;

public class HeadTiltInteraction : MonoBehaviour
{
    public Transform headBone;
    public float maxTiltAngle = 30f;
    public float tiltSpeed = 50f;

    private float currentTilt = 0f;
    private bool isActive = false;

    void Update()
    {
        if (!isActive) return;

        if (Input.GetMouseButton(0))
        {
            float mouseY = Input.GetAxis("Mouse Y");

            if (mouseY < -0.01f)
            {
                currentTilt += -mouseY * tiltSpeed * Time.deltaTime;
                currentTilt = Mathf.Clamp(currentTilt, 0f, maxTiltAngle);

                if (headBone != null)
                    headBone.localRotation = Quaternion.Euler(currentTilt, 0f, 0f);
            }
        }
    }

    public void ActivateTilt()
    {
        isActive = true;
    }

    public void ResetTilt()
    {
        currentTilt = 0f;
        isActive = false;

        if (headBone != null)
            headBone.localRotation = Quaternion.identity;
    }
}
