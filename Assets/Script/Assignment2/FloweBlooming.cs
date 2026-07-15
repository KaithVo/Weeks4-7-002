using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GardenManager : MonoBehaviour
{
    // Plant reference
    public Transform plant;

    // UI
    public Slider sunlightSlider;
    public TMP_Text growthText;
    public TMP_Text waterText;
    public TMP_Text timerText;


    // Water drop prefab
    public GameObject waterDropPrefab;

    // Flower prefab
    public GameObject flowerPrefab;


    // Spawn positions
    public Transform flowerSpawnPoint;


    // Water settings
    public int waterAmount = 10;
    public float waterSpawnHeight = 5f;


    // Flower settings
    public int flowerAmount = 1;


    // Plant data
    private float growth = 0;
    private int waterCount = 0;


    // Timer
    public float maxTime = 10f;
    private float currentTime;



    void Start()
    {
        currentTime = maxTime;

        UpdateUI();
    }



    void Update()
    {
        // Countdown timer
        currentTime -= Time.deltaTime;


        if (currentTime <= 0)
        {
            currentTime = 0;


            // Plant loses growth when dry
            growth -= 5 * Time.deltaTime;

            growth = Mathf.Clamp(growth, 0, 100);

            UpdatePlant();
            UpdateUI();
        }

        timerText.text = "Time: " + currentTime.ToString("F1");
    }

    // Button calls this function
    public void WaterPlant()
    {
        waterCount++;

        // Increase plant growth
        growth += 10;

        growth = Mathf.Clamp(growth, 0, 100);

        // Reset timer
        currentTime = maxTime;

        // Create falling water
        SpawnWaterDrops();

        // Create blooming flower
        SpawnFlower();

        UpdatePlant();
        UpdateUI();
    }

    void SpawnWaterDrops()
    {
        for (int i = 0; i < waterAmount; i++)
        {

            float randomX = Random.Range(-3f, 3f);


            Vector3 spawnPosition = new Vector3(
                randomX,
                waterSpawnHeight,
                0
            );


            GameObject water = Instantiate(
                waterDropPrefab,
                spawnPosition,
                Quaternion.identity
            );


            Destroy(water, 3f);
        }
    }

    void SpawnFlower()
    {
        Vector3 position = flowerSpawnPoint.position;


        GameObject flower = Instantiate(
            flowerPrefab,
            position,
            Quaternion.identity
        );


        // Remove flower after 10 seconds
        Destroy(flower, 10f);
    }

    void UpdatePlant()
    {

        // Slider controls plant size
        float sunlight = sunlightSlider.value / 100f;


        float size = 0.5f +
            (growth / 100f) * sunlight;


        plant.localScale =
            Vector3.one * size;
    }

    public void SliderChanged()
    {
        UpdatePlant();
    }

    void UpdateUI()
    {
        growthText.text =
            "Growth: " + growth.ToString("F0") + "%";


        waterText.text =
            "Water: " + waterCount;
    }
}