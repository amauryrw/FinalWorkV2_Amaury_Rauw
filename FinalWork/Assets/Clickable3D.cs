using UnityEngine;
using Fungus;

public class Clickable3D : MonoBehaviour
{
    public Flowchart flowchart;
    public string blockName;

    void OnMouseDown()
    {
        if (flowchart != null && !string.IsNullOrEmpty(blockName))
        {
            flowchart.ExecuteBlock(blockName);
        }
    }
}
