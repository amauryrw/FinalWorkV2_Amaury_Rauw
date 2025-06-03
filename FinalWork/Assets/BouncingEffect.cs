using UnityEngine;

public class BouncingEffect : MonoBehaviour
{
    public float amplitude = 0.2f;
    public float frequency = 2f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = startPos + Vector3.up * Mathf.Sin(Time.time * frequency) * amplitude;
    }
}
