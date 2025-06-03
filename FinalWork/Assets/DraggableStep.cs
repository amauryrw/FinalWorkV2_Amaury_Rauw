using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableStep : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    private GameObject placeholder = null;
    private Transform placeholderParent = null;
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Créer un objet temporaire pour réserver la place
        placeholder = new GameObject("Placeholder");
        placeholder.transform.SetParent(this.transform.parent);

        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        LayoutElement sourceLE = GetComponent<LayoutElement>();
        if (sourceLE != null)
        {
            le.preferredHeight = sourceLE.preferredHeight;
            le.flexibleHeight = 0;
        }

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;

        this.transform.SetParent(this.transform.root); // Décroche temporairement
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (placeholderParent == null || transform == null)
            return;

        this.transform.position = eventData.position;

        // Repositionne le placeholder dynamiquement
        int newSiblingIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.y > placeholderParent.GetChild(i).position.y)
            {
                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

        canvasGroup.blocksRaycasts = true;

        if (placeholder != null)
            Destroy(placeholder);
    }
}
