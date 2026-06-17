using UnityEngine;
using TMPro;
using UnityEngine.InputSystem; 

public class Detection : MonoBehaviour

{
    public string description;
    public TextMeshProUGUI descriptiontext;
    private SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0f;

        bool isMouseOver = sprite.bounds.Contains(worldMousePosition);

        if (isMouseOver)
        {
            descriptiontext.text = description;
        }
        else
        {
            if (descriptiontext.text == description)
            {
                descriptiontext.text = "";
            }
        }
    }
}
