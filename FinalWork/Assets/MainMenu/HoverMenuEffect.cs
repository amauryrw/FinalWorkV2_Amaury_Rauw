using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMenuEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    private Vector3 targetScale;
    private float scaleSpeed = 10f;

    private void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    private void Update()
{
    Vector3 previousScale = transform.localScale;
    transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);

    // Corriger le décalage vers la gauche
    float scaleDelta = transform.localScale.x - previousScale.x;
    transform.localPosition -= new Vector3(scaleDelta * GetComponent<RectTransform>().rect.width / 2, 0, 0);
}

    public void OnPointerEnter(PointerEventData eventData)
    {
        MenuHoverManager.Instance.OnButtonHover(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MenuHoverManager.Instance.OnButtonExit(gameObject);
    }

    public void SetScale(float scale)
    {
        targetScale = originalScale * scale;
    }
}
