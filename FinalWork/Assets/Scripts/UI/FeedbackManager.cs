using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    public GameObject feedbackPanel; // Fond noir
    public GameObject[] feedbackImages; // Tableau contenant toutes tes images

    private int currentImageIndex = -1; // Pour se souvenir quelle image est active

    public void ShowFeedback(int imageIndex)
    {
        feedbackPanel.SetActive(true);

        // Désactiver toutes les images d'abord
        foreach (var img in feedbackImages)
        {
            img.SetActive(false);
        }

        // Activer juste l'image souhaitée
        if (imageIndex >= 0 && imageIndex < feedbackImages.Length)
        {
            feedbackImages[imageIndex].SetActive(true);
            currentImageIndex = imageIndex;
        }
    }

    public void HideFeedback()
    {
        feedbackPanel.SetActive(false);

        // Désactiver l'image active
        if (currentImageIndex >= 0 && currentImageIndex < feedbackImages.Length)
        {
            feedbackImages[currentImageIndex].SetActive(false);
        }

        currentImageIndex = -1;
    }
}
