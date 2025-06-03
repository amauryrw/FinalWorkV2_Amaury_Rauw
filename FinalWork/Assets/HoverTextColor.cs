using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverTextColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI textToChange;
    public Color normalColor = Color.white;
    public Color hoverColor = Color.yellow;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (textToChange != null)
            textToChange.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (textToChange != null)
            textToChange.color = normalColor;
    }
}
