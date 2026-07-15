using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GardenManager : MonoBehaviour
{
    public Slider sunlightSlider;

    //connect flower growing
    public Transform plant;

    //tmpro
    public TMP_Text waterText;
    public TMP_Text growthText;
    public TMP_Text timerText;

    // Water drop prefab
    public GameObject waterDropPrefab;
    // Flower prefab
    public GameObject flowerPrefab;

    public Transform flowerSpawnPoint;

    //water spawn
    public float waterSpawnHeight = 5f;
    public int waterDropAmount = 10;

    public float maxTime = 10f;

    private float currentTime;
    private float growth = 0f;
    private int waterCount = 0;


    void Start()
    {
        currentTime = maxTime;
        UpdatePlant();
        UpdateUI();

    }


    void Update()
    {
        if (currentTime <= 0)
        {
            currentTime = 0;

            // Plant slowly shrinks if not watered
            if (growth > 0)
            {
                growth -= 5f * Time.deltaTime;
                growth = Mathf.Clamp(growth, 0, 100);

                UpdatePlant();
                UpdateUI();
            }
        }
    }


    // Connected to Water Button
    public void WaterPlant()
    {
        //water updateing 
        waterCount++;

        //increase growth
        growth += 10f;
        growth = Mathf.Clamp(growth, 0, 100);


        // Create water drops
        SpawnWaterDrops();

     
        UpdatePlant();
        UpdateUI();
    }

    void SpawnWaterDrops()
    {
        for (int i = 0; i < waterDropAmount; i++)
        {
            // Random X position between -3 and 3
            float randomX = Random.Range(-3f, 3f);

            Vector3 spawnPosition = new Vector3(randomX, waterSpawnHeight, 0);


            GameObject drop = Instantiate(waterDropPrefab, spawnPosition, Quaternion.identity);

            Destroy(drop, 3f); // destroy after 3s
        }
    }

    void SpawnFlower()
    {
        GameObject flower = Instantiate(flowerPrefab,flowerSpawnPoint.position,Quaternion.identity);

        // Let FlowerBlooming handle the animation
        Destroy(flower, 8f);
    }


    //change  clider to control the groth also
    public void SliderChanged()
    {
        UpdatePlant();
    }

    void UpdatePlant()

    {
        //using the same slide value of the sky background
        float sunlightAmount = sunlightSlider.value / sunlightSlider.maxValue;

        float size = 0.5f * sunlightAmount;

        plant.localScale = Vector3.one * size;
    }

    void UpdateUI()
    {
        // https://stackoverflow.com/questions/62601152/unity-countdown-with-scenemanager
        //showing %
        growthText.text = "Growth: " + growth.ToString("F0") + "%";
        waterText.text = "Watered: " + waterCount;
    }
}