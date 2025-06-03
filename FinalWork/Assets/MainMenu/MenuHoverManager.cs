using UnityEngine;
using System.Collections.Generic;

public class MenuHoverManager : MonoBehaviour
{
    public static MenuHoverManager Instance;

    public float hoveredScale = 1.2f;
    public float normalScale = 0.9f;

    private List<HoverMenuEffect> allButtons = new List<HoverMenuEffect>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        allButtons.AddRange(FindObjectsOfType<HoverMenuEffect>());
    }

    public void OnButtonHover(GameObject hovered)
    {
        foreach (var btn in allButtons)
        {
            if (btn.gameObject == hovered)
                btn.SetScale(hoveredScale);
            else
                btn.SetScale(normalScale);
        }
    }

    public void OnButtonExit(GameObject exited)
    {
        foreach (var btn in allButtons)
        {
            btn.SetScale(1f); // Retour à l’échelle normale
        }
    }
}
