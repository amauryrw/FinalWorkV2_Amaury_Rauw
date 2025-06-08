using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    public float bounceSpeed = 2f;   
    public float bounceAmount = 0.1f; 

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * bounceSpeed) * bounceAmount;
        transform.localScale = initialScale * scale;
    }
}
