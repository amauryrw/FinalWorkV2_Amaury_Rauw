using UnityEngine;

public class TogglePanelWithESC : MonoBehaviour
{
    public GameObject panel; 
    public PlayerControllerToggle controllerToggle; 

    private bool panelOpenedFromESC = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC pressed");
            // Si le panel est inactif on veut l'ouvrir
            if (!panel.activeSelf)
            {
                // On fait rien si les contrôles sont déjà désactivés
                if (controllerToggle != null && !controllerToggle.ControlsEnabled)
                    return;

                // Sinon on ouvre le panel
                panel.SetActive(true);
                controllerToggle.DisableControls();
                panelOpenedFromESC = true;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                // Si on ferme le panel on réactive les contrôles que si c'est ESC qui l'avait ouvert
                panel.SetActive(false);

                if (panelOpenedFromESC && controllerToggle != null)
                    controllerToggle.EnableControls();

                panelOpenedFromESC = false;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
