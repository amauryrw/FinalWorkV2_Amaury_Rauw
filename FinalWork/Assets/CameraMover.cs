using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject arrowObjectToDisable;
    public float moveDuration = 1.5f;

    [Header("Cibles de la caméra")]
    public Transform mouthTarget;
    public Transform chestTarget;
    public Transform defaultTarget; 

    public void MoveCameraToMouth()
    {
        if (mouthTarget != null)
        {
            StartCoroutine(MoveCameraSmoothly(mouthTarget.position, mouthTarget.rotation));
        }
        else
        {
            Debug.LogWarning("Aucune cible définie pour la bouche.");
        }
    }

    public void MoveCameraToChest()
    {
        if (chestTarget != null)
        {
            if (arrowObjectToDisable != null && arrowObjectToDisable.activeSelf)
            {
                arrowObjectToDisable.SetActive(false);
            }
            StartCoroutine(MoveCameraSmoothly(chestTarget.position, chestTarget.rotation));
        }
        else
        {
            Debug.LogWarning("Aucune cible définie pour le torse.");
        }
    }

    public void MoveCameraToDefault()
    {
        if (defaultTarget != null)
        {
            StartCoroutine(MoveCameraSmoothly(defaultTarget.position, defaultTarget.rotation));
        }
        else
        {
            Debug.LogWarning("Aucune cible définie pour la position par défaut.");
        }
    }

    IEnumerator MoveCameraSmoothly(Vector3 targetPosition, Quaternion targetRotation)
    {
        float elapsed = 0f;
        Vector3 startPos = mainCamera.transform.position;
        Quaternion startRot = mainCamera.transform.rotation;

        while (elapsed < moveDuration)
        {
            float t = elapsed / moveDuration;
            mainCamera.transform.position = Vector3.Lerp(startPos, targetPosition, t);
            mainCamera.transform.rotation = Quaternion.Slerp(startRot, targetRotation, t);
            elapsed += Time.deltaTime;
            if (arrowObjectToDisable != null && arrowObjectToDisable.activeSelf)
            {
                arrowObjectToDisable.SetActive(false);
            }
            yield return null;
        }

        mainCamera.transform.position = targetPosition;
        mainCamera.transform.rotation = targetRotation;
    }
}
