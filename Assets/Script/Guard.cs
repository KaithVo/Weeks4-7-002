using UnityEngine;

public class Guard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform player;
    public float speed;
    bool isFollowing = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing && player != null)
        {
            // Use player's transform.position instead of player.position
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    public void StartFollowing()
    {
        isFollowing = true;
    }

    public void StopFollowing()
    {
        isFollowing = false;
    }
}
