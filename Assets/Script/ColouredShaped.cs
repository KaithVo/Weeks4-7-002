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
        PickSprite();

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            if (sprites.Count > 0)
            {
                //use that to set the sprite
                PickSprite();
            }
        }

        t += Time.deltaTime;
        spriteRenderer.color = Random.ColorHSV(); 

        //creat condition if anykey is down
    }


    void PickSprite()
    {
        //pick a random index from the list of sprites
        spriteIndex = Random.Range(0, sprites.Count);
        //use that to set the sprite
        spriteRenderer.sprite = sprites[spriteIndex];
       
    }
}
