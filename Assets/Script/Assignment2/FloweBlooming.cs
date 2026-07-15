using System;
using UnityEngine;

public class FloweBlooming : MonoBehaviour
{
    public float speed = 0.5f; //blooming speed
    // Smallest and largest size
    public Vector3 originalScale;
    public Vector3 IsExpanding = new Vector3(1.5f, 1.5f, 1.5f);

    // Height where the flower reaches full bloom
    public float bloomHeight = 2f;

    // Remember where it started
    private float startHeight;

    //time
    public AnimationCurve curve;
    public SpriteRenderer flowerRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flowerRenderer = GetComponent<SpriteRenderer>();

        //start scale
        originalScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        // Calculate how difference the flower has moved
        float heightDifference = transform.position.y - startHeight;

        // Convert height into 0-1 value like the t/duration trick
        float bloomProgress = heightDifference / bloomHeight;

        bloomProgress = Mathf.Clamp01(bloomProgress);

        //if bloom over 1f then stop

        if (bloomProgress < 1f)
        {
            // Move flower upward
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        // Grow flower smoothly
        transform.localScale = Vector3.Lerp(originalScale, IsExpanding, curve.Evaluate(bloomProgress));
    }
}