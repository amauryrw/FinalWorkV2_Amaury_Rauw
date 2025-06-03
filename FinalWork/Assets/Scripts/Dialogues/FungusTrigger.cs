using UnityEngine;
using UnityEngine.UI;
using Fungus;
using TMPro;

public class FungusTrigger : MonoBehaviour
{
    public Flowchart flowchart;

    [Header("Start Screen Setup")]
    public GameObject startScreenUI; 
    public Button startButton;
    private bool gameStarted = false;

    [Header("Camera Setup")]
    public Camera playerCamera;
    public Transform cameraTargetPosition;
    public float cameraMoveSpeed = 2f;
    private Vector3 originalCameraPosition;
    private Quaternion originalCameraRotation;
    private Transform originalCameraParent;
    private bool moveCameraToTarget = false;
    private bool isCameraInDialogue = false;

    [Header("Player Setup")]
    public GameObject player;
    private playerMovementScript playerMovement;
    private MouseLook mouseLook;

    [Header("UI Setup")]
    public GameObject interactionUI;

    private bool isPlayerNearby = false;

    void Start()
    {
        if (player != null)
            playerMovement = player.GetComponent<playerMovementScript>();

        if (playerCamera != null)
            mouseLook = playerCamera.GetComponent<MouseLook>();

        interactionUI.SetActive(false);

        FreezeCamera();

        if (startScreenUI != null)
        {
            startScreenUI.SetActive(true);
            if (startButton != null)
                startButton.onClick.AddListener(StartGame);
        }
    }

    void Update()
    {
        if (!gameStarted) return;

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            interactionUI.SetActive(false);
            StartDialogue();
        }

        if (moveCameraToTarget && playerCamera != null && cameraTargetPosition != null)
        {
            playerCamera.transform.position = Vector3.Lerp(
                playerCamera.transform.position,
                cameraTargetPosition.position,
                Time.deltaTime * cameraMoveSpeed
            );

            playerCamera.transform.rotation = Quaternion.Slerp(
                playerCamera.transform.rotation,
                cameraTargetPosition.rotation,
                Time.deltaTime * cameraMoveSpeed
            );
        }
    }

    public void StartGame()
    {
        gameStarted = true;

        if (startScreenUI != null)
            startScreenUI.SetActive(false);

        UnfreezeCamera();
    }

    public void StartDialogue()
    {
        if (playerCamera != null && !isCameraInDialogue)
        {
            originalCameraPosition = playerCamera.transform.position;
            originalCameraRotation = playerCamera.transform.rotation;
            originalCameraParent = playerCamera.transform.parent;
            playerCamera.transform.parent = null;
            isCameraInDialogue = true;
        }

        FreezeCamera();
        moveCameraToTarget = true;

        if (interactionUI != null)
            interactionUI.SetActive(false);

        if (flowchart != null)
            flowchart.ExecuteBlock("StartDialogue");
    }

    public void EndDialogue()
    {
        if (playerCamera != null && isCameraInDialogue)
        {
            playerCamera.transform.position = originalCameraPosition;
            playerCamera.transform.rotation = originalCameraRotation;
            if (originalCameraParent != null)
                playerCamera.transform.parent = originalCameraParent;
            isCameraInDialogue = false;
        }

        moveCameraToTarget = false;
        UnfreezeCamera();
    }

    void FreezeCamera()
    {
        if (playerMovement != null)
            playerMovement.enabled = false;

        if (mouseLook != null)
            mouseLook.enabled = false;

        if (player != null)
        {
            CharacterController cc = player.GetComponent<CharacterController>();
            if (cc != null)
                cc.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnfreezeCamera()
    {
        if (playerMovement != null)
            playerMovement.enabled = true;

        if (mouseLook != null)
            mouseLook.enabled = true;

        if (player != null)
        {
            CharacterController cc = player.GetComponent<CharacterController>();
            if (cc != null)
                cc.enabled = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        isPlayerNearby = true;

        if (interactionUI != null && !isCameraInDialogue)
            interactionUI.SetActive(true);
    }
}

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }
}
