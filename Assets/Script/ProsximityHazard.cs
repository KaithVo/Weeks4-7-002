using UnityEngine;
using UnityEngine.Events;

public class ProsximityHazard : MonoBehaviour
{
    public SpriteRenderer playerRenderer;
    public Explorer playerExplorer;

    public UnityEvent onTrapEntered;
    public UnityEvent onTrapExited;

    bool isCurrentlyOnTrap = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If we were not on the trap and have just stepped onto it
        if (playerRenderer.bounds.Contains(transform.position)
            && !isCurrentlyOnTrap)
        {
            onTrapEntered.Invoke();
            //Then we are now on the trap and we take damage
            isCurrentlyOnTrap = true;
        }

        //If we were on the trap and have just stepped off of it
        if (!playerRenderer.bounds.Contains(transform.position)
            && isCurrentlyOnTrap)
        {
            onTrapExited.Invoke();
            isCurrentlyOnTrap = false;
        }

    }
}
