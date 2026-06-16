using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CollectionExample : MonoBehaviour
{

    private List<string> animals;
    public SpriteRenderer spriteRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        int number = 1;
        float decimalNumber = 1.5f;
        string word = "Cow";

        Vector3 position = new Vector3(1f, 0f,0f);
        position.x = 4f;

        Color colorGrey = new Color(0.5f, 0.5f, 0.5f,1f);
        colorGrey.b = 0.75f;
        spriteRenderer.color = colorGrey;

        animals = new List<string>();
        animals.Add("Raccoon");
        //animals.Remove("Dog");


       
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < animals.Count; i++)
        {
            Debug.Log(animals[i]);
        }
    }
}
