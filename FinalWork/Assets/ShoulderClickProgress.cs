using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class ShoulderClickProgress : MonoBehaviour
{
    public Image progressCircle;
    public GameObject Arrow; // Objet avec Animator
    public GameObject instructionText;
    public float holdTime = 10f;
    public Flowchart flowchart;
    public string fungusBlockName = "SlachtofferOnbewust";

    private float holdProgress = 0f;
    private bool isHolding = false;
    private bool interactionStarted = false;

    void Start()
    {
        if (progressCircle != null)
            progressCircle.gameObject.SetActive(false);

        if (Arrow != null)
            Arrow.SetActive(false);
    }

    void Update()
    {
        if (interactionStarted && isHolding && Input.GetMouseButton(0) &&
            (Mathf.Abs(Input.GetAxis("Mouse X")) > 0.1f || Mathf.Abs(Input.GetAxis("Mouse Y")) > 0.1f))
        {
            holdProgress += Time.deltaTime;
            progressCircle.fillAmount = holdProgress / holdTime;

            if (holdProgress >= holdTime)
            {
                if (progressCircle != null)
                    progressCircle.gameObject.SetActive(false);

                if (Arrow != null)
                    Arrow.SetActive(false);
                    Arrow.GetComponent<Image>().enabled = false;
                    Arrow.GetComponent<Animator>().enabled = false;

                if (instructionText != null)
                    instructionText.SetActive(false);

                if (flowchart != null)
                    flowchart.ExecuteBlock(fungusBlockName);

                isHolding = false;
            }
        }
        else if (interactionStarted && holdProgress > 0f)
        {
            holdProgress -= Time.deltaTime;
            if (holdProgress < 0f) holdProgress = 0f;

            if (progressCircle != null)
                progressCircle.fillAmount = holdProgress / holdTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    StartHold();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isHolding = false;
        }
    }

    void StartHold()
    {
        interactionStarted = true;
        isHolding = true;
        holdProgress = 0f;

        if (Arrow != null)
            Arrow.SetActive(true); // L’Animator démarre automatiquement

        if (progressCircle != null)
        {
            progressCircle.fillAmount = 0f;
            progressCircle.gameObject.SetActive(true);
        }

        if (instructionText != null)
            instructionText.SetActive(false);
    }
}
