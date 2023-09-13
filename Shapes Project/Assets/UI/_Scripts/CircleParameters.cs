using System;
using UnityEngine;
using TMPro;

public class CircleParameters : MonoBehaviour
{
	public string diameterText;
	[HideInInspector] // The circle shape that is being modified.
	public Circle circleRef;
	
	[SerializeField]
	private TextMeshProUGUI textDiameterRef;
	
	private SliderElement _radiusSliderRef;
	private ShapeParameters _shapeParametersRef;
	
	// subscribe to the slider's OnSliderValueChanged event.
	private void OnEnable()
	{
		_radiusSliderRef = GetComponentInChildren<SliderElement>();
		_shapeParametersRef = GetComponentInChildren<ShapeParameters>();
		if (!_radiusSliderRef)
		{
			Debug.LogError($"{this.name} - Slider not found!");
		}
		else
		{
			_radiusSliderRef.OnSliderValueChanged += OnRadiusUpdated;
		}
	}

	// unsubscribe from the slider's OnSliderValueChanged event.
	private void OnDestroy()
	{
		if (!_radiusSliderRef) return;
		
		_radiusSliderRef.OnSliderValueChanged -= OnRadiusUpdated;
	}

	// Start is called before the first frame update
	void Start()
	{
		if (!circleRef) return; // if the circle reference is null, return.
		
		// Radius text is already set on the "VariableSlider" prefab.
		SetDiameterText(circleRef.GetDiameter());
	}
	
	private void OnRadiusUpdated(float newRadius)
	{
		if (!circleRef || !_shapeParametersRef) return; // if the circle reference or shape script is null, return.
		
		// Update the circle's radius.
		circleRef.SetRadius(newRadius);
		
		// Update the diameter text.
		SetDiameterText(circleRef.GetDiameter());
		
		// Update the general shape parameters text.
		_shapeParametersRef.SetAreaText(circleRef.GetShapeArea());
		_shapeParametersRef.SetPerimeterText(circleRef.GetShapePerimeter());
	}
	
	public void SetDiameterText(float value)
	{
		textDiameterRef.text = $"{diameterText} {value:F}";
	}
}
