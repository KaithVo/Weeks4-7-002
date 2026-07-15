using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public float fallSpeed = 5f;

    void Start()
    {

    }
    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }
}