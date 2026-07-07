using UnityEngine;
using UnityEngine.InputSystem;

public class Explorer : MonoBehaviour
{
    public float health;
    public float speed;
    public int treasureCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToMove = Vector3.zero;

        //This is the constructor for Vector3
        directionToMove = new Vector3(0, 0, 0);

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            directionToMove.x -= 1f;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            directionToMove.x += 1f;
        }

        if (Keyboard.current.upArrowKey.isPressed)
        {
            directionToMove.y += 1f;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            directionToMove.y -= 1f;
        }

        transform.position += directionToMove * speed * Time.deltaTime;
    }

   public void TakeDamage()
    {
        health -= 10;
    }

    public void SlowSpeed()
    {
        speed -= 1.5f;
    }

    public void IncreaseSpeed()
    {
        speed += 1.5f;
    }

}