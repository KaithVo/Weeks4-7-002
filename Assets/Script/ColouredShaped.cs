using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class ColouredShaped : MonoBehaviour

{
    public List<Sprite> sprites; 
    public SpriteRenderer spriteRenderer;
    public int spriteIndex; 

    public float t;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if( sprites.Count > 0)
        {
            //use that to set the sprite
            spriteRenderer.sprite = sprites[spriteIndex]; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        spriteRenderer.color = Random.ColorHSV(); 

        //creat condition if anykey is down

        if (Input.anyKeyDown)
        {
            spriteIndex +=1 ; 
        }


    }
}
