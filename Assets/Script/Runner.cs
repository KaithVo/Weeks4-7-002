using UnityEngine;

public class Runner : MonoBehaviour
{

    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.right;
    }
}
