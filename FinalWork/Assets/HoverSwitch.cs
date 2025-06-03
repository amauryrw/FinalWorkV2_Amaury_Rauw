using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverSwitch : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
     public Image targetImage;           
    public Sprite normalSprite;         
    public Sprite hoverSprite;         

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetImage != null && hoverSprite != null)
        {
            targetImage.sprite = hoverSprite;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (targetImage != null && normalSprite != null)
        {
            targetImage.sprite = normalSprite;
        }
    }
}
