using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GardenManager : MonoBehaviour
{
    public Transform plant;
    public TMP_Text waterText;

    // Water drop prefab
    public GameObject waterDropPrefab;

    public int dropAmount = 10;
    public float spawnHeight = 5f;

    private float growth = 0f;
    private int waterCount = 0;

    public float maxTime = 10f;
    private float currentTime;


    void Start()
    {
        UpdateUI();

    }


    void Update()
    {
 
    }


    // Connected to Water Button
    public void WaterPlant()
    {
        waterCount++;

        growth += 10f;
        growth = Mathf.Clamp(growth, 0, 100);


        // Create water drops
        SpawnWaterDrops();

        UpdateUI();
    }

    void SpawnWaterDrops()
    {
        for (int i = 0; i < dropAmount; i++)
        {
            // Random X position between -3 and 3
            float randomX = Random.Range(-3f, 3f);

            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0);


            GameObject drop = Instantiate(waterDropPrefab, spawnPosition, Quaternion.identity);

        }
    }

    void UpdateUI()
    {


        waterText.text = "Watered: " + waterCount;
    }
}