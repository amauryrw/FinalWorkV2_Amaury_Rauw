using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class StartScreenUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Button startButton;
    public GameObject player; // Le joueur pour geler ses mouvements
    public Camera playerCamera; // La caméra pour geler la rotation

    private playerMovementScript playerMovement;
    private MouseLook mouseLook;

    public float fadeDuration = 2f;

    private void Start()
    {
        if (player != null)
            playerMovement = player.GetComponent<playerMovementScript>();

        if (playerCamera != null)
            mouseLook = playerCamera.GetComponent<MouseLook>();

        // Bloquer le mouvement au début
        FreezePlayer();

        canvasGroup.alpha = 0f;
        startButton.interactable = false;

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
        startButton.interactable = true;
    }

    public void OnStartButtonClicked()
    {
        UnfreezePlayer(); // Débloque le joueur
        gameObject.SetActive(false); // Cache l'écran
    }

    void FreezePlayer()
    {
        if (playerMovement != null)
            playerMovement.enabled = false;

        if (mouseLook != null)
            mouseLook.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void UnfreezePlayer()
    {
        if (playerMovement != null)
            playerMovement.enabled = true;

        if (mouseLook != null)
            mouseLook.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
