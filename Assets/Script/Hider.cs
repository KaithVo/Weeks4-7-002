using UnityEngine;

public class Hider : MonoBehaviour
{

    public Vector3 hidePosition;
    public int x;
    public float y;

    public void Hide()
    {
        transform.position = hidePosition;
    }   
}
