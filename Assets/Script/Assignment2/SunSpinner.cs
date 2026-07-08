using UnityEngine;
using UnityEngine.UI;

public class SunSpinner : MonoBehaviour
{
    public Slider sunlightSlider;

    // Maximum rotation amount
    public float rotationAmount = 360f;

    private Vector3 startRotation;


    void Start()
    {
        // Save the original rotation
        startRotation = transform.eulerAngles;
    }


    void Update()
    {
        RotateWithSlider();
    }


    public void RotateWithSlider()
    {
        // Get slider value (0-1)
        float sliderValue = sunlightSlider.value / sunlightSlider.maxValue;

        // Calculate rotation based on slider
        float zRotation = sliderValue * rotationAmount;

        // Apply rotation
        transform.eulerAngles = new Vector3( startRotation.x,startRotation.y,startRotation.z - zRotation);
    }
}