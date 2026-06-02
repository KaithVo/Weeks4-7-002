using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public GameObject runnerPrefab;
    public GameObject existingRunner;
    public Vector3 spawnPosition;
    public float spawnSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Destroy(existingRunner, 3f);
        }
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
        }
    }

    public void OnSpawnPress()
    {

    
        //Spawn a runner!
        //Instantiate(runnerPrefab);

        //Spawn a runner that is a child of this object
        //Instantiate(runnerPrefab, transform);

        //Spawn a runner at a specific position with no rotation:
        GameObject spawnedObject = Instantiate(runnerPrefab, transform.position, Quaternion.identity);
        //Spawn a runner at a specific position with a specific rotation:
        SpriteRenderer spawnedObjectRender = spawnedObject.GetComponent<SpriteRenderer>();
        // if the spawned object has a sprite renderer component, then we can set the color of the sprite to a random color
        // using the Random.ColorHSV() function, which generates a random color in the HSV color space.    
        if (spawnedObjectRender != null)
        {
            spawnedObjectRender.color = Random.ColorHSV();
        }

        Runner spawnedRunner = spawnedObject.GetComponent<Runner>();

        //Getcomponent is to call the script that is attached to the spawned object, in this case the runner script,
        //and then we can set the speed of the runner to the spawnSpeed variable that we have set in the inspector
        if (spawnedRunner != null)//check if the spawned object has a runner script attached to it
        {
            spawnedRunner.speed = spawnSpeed;
        }


        Destroy(spawnedObject, 2f);

        //POSITION OF ZERO:
        //Vector3 zeroVector = Vector3.zero;

        //ROTATION OF ZERO:
        //Quaternion zeroRotation = Quaternion.identity;
    }
}
