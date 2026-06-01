using UnityEngine;

public class ColouredShaped : MonoBehaviour

{
    public SpriteRenderer spriteRenderer;
    public float t;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        spriteRenderer.color = Random.ColorHSV(); 

    }
}
