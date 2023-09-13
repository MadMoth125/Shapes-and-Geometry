using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderElement : MonoBehaviour
{
	public event Action<float> OnSliderValueChanged;
	
	[Header("Slider Settings")]
	public string sliderText = "Var name:";
	public float sliderValueMin = 0.0f;
	public float sliderValueMax = 1.0f;
	public float sliderValueDefault = 0.5f;
	
	public TextMeshProUGUI TextRef { get; private set; }
	public Slider SliderRef { get; private set; }

	private void OnEnable()
	{
		TextRef = GetComponentInChildren<TextMeshProUGUI>();
		if (!TextRef) Debug.LogError($"{this.name} - Text not found!");
		
		SliderRef = GetComponentInChildren<Slider>();
		if (!SliderRef) Debug.Log($"{this.name} - Slider not found!");
	}

	// Start is called before the first frame update
	void Start()
	{
		if (SliderRef != null)
		{
			SliderRef.minValue = sliderValueMin;
			SliderRef.maxValue = sliderValueMax;
			SliderRef.value = sliderValueDefault;
			
			// Initialize the text to the default value of the slider.
			OnSliderUpdated(SliderRef.value);
		}
	}

	public void OnSliderUpdated(float value)
	{
		if (!TextRef) return;
		
		TextRef.text = $"{sliderText} {value:F}";
		OnSliderValueChanged?.Invoke(value);
		
	}
}
