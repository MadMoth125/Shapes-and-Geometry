using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CircleRadiusElement : MonoBehaviour
{
    public string sliderText = "Circle Radius:";
    public TextMeshProUGUI TextRadiusRef { get; private set; }
    public Slider SliderRef { get; private set; }

    private void OnEnable()
    {
        TextRadiusRef = GetComponentInChildren<TextMeshProUGUI>();
        if (TextRadiusRef == null) Debug.LogError("Text not found!");
        
        SliderRef = GetComponentInChildren<Slider>();
        if (SliderRef == null) Debug.Log("Slider not found!");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the text to the default value of the slider.
        OnSliderUpdated(SliderRef.value);
    }

    public void OnSliderUpdated(float value)
    {
        TextRadiusRef.text = $"{sliderText} {value:F}";
    }
}
