/*using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 


public class TalkTrigger : MonoBehaviour
{

    public Image heart1; 
    public Image heart2;
    public Image heart3;

    public Image Emptyheart1; 
    public Image Emptyheart2;
    public Image Emptyheart3;

    private int lives = 3;

    [Header("Game Over UI")]
    public GameObject gameOverUI; //  le panneau GameOver
    public Button restartButton;   //  bouton Restart


    [Header("New Start UI")] 
    public GameObject startScreenUI; //  UI de démarrage
    public Button startButton;        //  Bouton Start

    public GameObject Health;
    public Transform cameraTargetPosition;
    public float cameraMoveSpeed = 2f;
    private bool moveCameraToTarget = false;

    private Vector3 originalCameraPosition;
    private Quaternion originalCameraRotation;
    private Transform originalCameraParent;
    private bool isCameraInDialogue = false;

    public GameObject buttonsContainer;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public GameObject interactionUI;
    public GameObject dialogueUI;
    public string[] dialogueLines;
    public Camera playerCamera;
    public GameObject player;
    private playerMovementScript playerMovement;
    private MouseLook mouseLook;

    private bool isPlayerNearby = false;
    private int dialogueIndex = 0;

    private NPCLookAtPlayer lookScript;
    private Animator npcAnimator;

    private bool gameStarted = false; // 🔥 Pour bloquer tant qu'on n'a pas cliqué Start

    void Start()


{
    gameOverUI.SetActive(false);
    restartButton.onClick.AddListener(RestartGame);
    Emptyheart1.enabled = false;
    Emptyheart2.enabled = false;
    Emptyheart3.enabled = false;
    // 🔥 Désactiver tout sauf l'écran de démarrage
    startScreenUI.SetActive(true);
    interactionUI.SetActive(false);
    dialogueUI.SetActive(false);

    lookScript = GetComponent<NPCLookAtPlayer>();
    npcAnimator = GetComponent<Animator>();

    if (player != null)
        playerMovement = player.GetComponent<playerMovementScript>();

    if (playerCamera != null)
        mouseLook = playerCamera.GetComponent<MouseLook>();

    // 🔥 Désactiver mouvement et caméra dès le début
    if (playerMovement != null) playerMovement.enabled = false;
    if (mouseLook != null) mouseLook.enabled = false;

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    // 🔥 Bloquer le jeu au début
    gameStarted = false;

    // 🔥 Connecter le bouton
    startButton.onClick.AddListener(StartGame);
}


    void Update()
    {
        if (!gameStarted) return; // 🔥 Ne rien faire tant que le jeu n'est pas lancé

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (npcAnimator != null && !npcAnimator.GetBool("Sit"))
            {
                npcAnimator.SetBool("Sit", true);

                if (player != null)
                {
                    Animator playerAnim = player.GetComponent<Animator>();
                    if (playerAnim != null)
                        playerAnim.SetTrigger("Talk");
                }

                if (lookScript != null)
                    lookScript.StartInteraction(player.transform);

                interactionUI.SetActive(false);
                dialogueUI.SetActive(true);

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
                DisplayNextLine();
            }
            else
            {
                DisplayNextLine();
            }
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
    startScreenUI.SetActive(false);
    gameStarted = true;

    // 🔥 Activer mouvement et caméra
    if (playerMovement != null) playerMovement.enabled = true;
    if (mouseLook != null) mouseLook.enabled = true;

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}

    void EndDialogue()
    {
        if (lookScript != null)
            lookScript.StopInteraction();

        if (npcAnimator != null)
        {
            npcAnimator.SetBool("Sit", false);
            npcAnimator.SetBool("isTalking", false);
        }

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
        buttonsContainer.SetActive(false);
    }

    void DisplayNextLine()
    {
        if (dialogueIndex < dialogueLines.Length)
        {
            dialogueUI.GetComponentInChildren<TextMeshProUGUI>().text = dialogueLines[dialogueIndex];

            if (npcAnimator != null)
            {
                npcAnimator.SetBool("isTalking", true);

                if (dialogueIndex == 0)
                    npcAnimator.SetTrigger("Talk1");
                else if (dialogueIndex == 1)
                    npcAnimator.SetTrigger("Talk2");
                else if (dialogueIndex == 2)
                    npcAnimator.SetTrigger("Talk3");
            }

            if (dialogueIndex == 2)
            {
                buttonsContainer.SetActive(true);
                FreezeCamera();
            }

            dialogueIndex++;
        }
        else
        {
            dialogueUI.SetActive(false);
            EndDialogue();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (npcAnimator != null && !npcAnimator.GetBool("Sit"))
                interactionUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionUI.SetActive(false);
            dialogueUI.SetActive(false);
            dialogueIndex = 0;

            if (lookScript != null)
                lookScript.StopInteraction();

            if (npcAnimator != null)
            {
                npcAnimator.SetBool("Sit", false);
                npcAnimator.SetBool("isTalking", false);
            }

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
    }

    void FreezeCamera()
    {
        if (playerMovement != null)
            playerMovement.enabled = false;

        if (mouseLook != null)
            mouseLook.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void UnfreezeCamera()
    {
        if (playerMovement != null)
            playerMovement.enabled = true;

        if (mouseLook != null)
            mouseLook.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void SetButtonColor(Button button, Color color)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = color;
        cb.highlightedColor = color;
        cb.selectedColor = color;
        cb.pressedColor = color;
        button.colors = cb;
    }

    void Loseheart()
{
    lives--;

    if (lives == 2)
    {
        heart3.enabled = false;
        Emptyheart3.enabled = true;
    }
    else if (lives == 1)
    {
        heart2.enabled = false;
        Emptyheart2.enabled = true;
    }
    else if (lives == 0)
    {
        heart1.enabled = false;
        Emptyheart1.enabled = true;

        GameOver(); 
    }
}


    

    void GameOver()
    {
        Debug.Log("Game over!");
        gameOverUI.SetActive(true);
        buttonsContainer.SetActive(false);
        interactionUI.SetActive(false);
        dialogueUI.SetActive(false);
        Health.SetActive(false);

        FreezeCamera();
    }

    void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ShowNextDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialogueUI.GetComponentInChildren<TextMeshProUGUI>().text = "You made the right choice! Click E to continue to the next scenario";
        buttonsContainer.SetActive(false);
    }

    public void OnButton1Clicked(){
        SetButtonColor(button1, Color.red);
        Loseheart();
    }
    public void OnButton2Clicked() {
        SetButtonColor(button2, Color.red);
        Loseheart();
    }
    public void OnButton3Clicked() {
        SetButtonColor(button3, Color.red);
        Loseheart();
    }
    public void OnButton4Clicked()
    {
        SetButtonColor(button4, Color.green);
        StartCoroutine(ShowNextDialogueAfterDelay(2f));
    }


}*/
