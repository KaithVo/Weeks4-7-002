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
    private float t = 0;
    public AnimationCurve curve;

    public SpriteRenderer flowerRenderer;                       

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flowerRenderer = GetComponent<SpriteRenderer>();

        //start psotion
        startHeight = transform.position.y;

        //start scale
        originalScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        //move up
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        t += Time.deltaTime * speed;
        t = Mathf.Clamp01(t);

        transform.localScale = Vector3.Lerp(originalScale, IsExpanding, curve.Evaluate(t));
    }
}
