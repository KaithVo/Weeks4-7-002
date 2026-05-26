using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;


public class Trainer : MonoBehaviour
{
    public SpriteRenderer creatureRenderer;
    public Camera gameCamera;
    public Color caughtColor;

    public List<SpriteRenderer> unCaughtcreatures; // List of creatures in the game
    public List<SpriteRenderer> caughtCreatures; // List of caught creatures

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isClicked = Mouse.current.leftButton.wasPressedThisFrame;
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = gameCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0; // Set z to 0 for 2D

        if (isClicked)
        {
            //CaughtCreature
            // for each element I want to output that to the console

            //FIRST SECTION: Define and set up the loop to iterate through the caughtCreatures list 
            //SECOND SECTION: Define when the loop will run (i.e., as long as i is less than the total number of elements in the caughtCreatures list)
            //THIRD SECTION: increase the value of i by 1 after each iteration to move to the next element in the list

            for (int i = 0; i < caughtCreatures.Count; i++)
            {
                Debug.Log(caughtCreatures[i]);
            }

            if (caughtCreatures.Count > 0)
            {
                Debug.Log(caughtCreatures[0]);
            }
        }

        if (isClicked && creatureRenderer.bounds.Contains(mousePosition))
        {
            creatureRenderer.color = caughtColor; // Change color to indicate it's caught
            Debug.Log("Caught the creature!");


            bool isCaughtCreature = caughtCreatures.Contains(creatureRenderer); // Check if the creature is already in the caught list
            Debug.Log("Is creature caught[" + isCaughtCreature.ToString() + "]");

            if (!isCaughtCreature)
            {
                unCaughtcreatures.Add(creatureRenderer); // Add from caught creatures list
            }
            caughtCreatures.Remove(creatureRenderer); // Remove to uncaught creatures list 
        }
        
    }
}
