using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class ChangeColorUI : MonoBehaviour
{
    public Image targetImage; // Le fond du dialogue à modifier

    public void SetColorRed()
    {
        if (targetImage != null)
        {
            targetImage.color = Color.red;
        }
    }

    public void SetColorWhite()
    {
        if (targetImage != null)
        {
            targetImage.color = Color.white;
        }
    }
}
