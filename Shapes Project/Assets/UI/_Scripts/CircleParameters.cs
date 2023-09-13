using System;
using UnityEngine;
using TMPro;

public class CircleParameters : ParametersBase
{
	[HideInInspector] // The circle shape that is being modified.
	public Circle circleRef;
	[SerializeField]
	private SliderElement _radiusSliderRef;
	
	[SerializeField] // the text element that displays the circle's Diameter.
	private TextMeshProUGUI textDiameterRef;
	public string diameterText;
	
	private ShapeParameters _shapeParametersRef;
	
	// subscribe to the slider's OnSliderValueChanged event.
	private void OnEnable()
	{
		// Get the shape parameters UI reference.
		_shapeParametersRef = GetComponentInChildren<ShapeParameters>();

		try
		{
			_radiusSliderRef.OnSliderValueChanged += OnRadiusUpdated;
		}
		catch
		{
			Debug.LogError($"{this.name} - Slider not found!");
		}
	}

	// unsubscribe from the slider's OnSliderValueChanged event.
	private void OnDestroy()
	{
		try
		{
			_radiusSliderRef.OnSliderValueChanged -= OnRadiusUpdated;
		}
		catch
		{
			// ignored
		}
	}

	private void Start()
	{
		/* Initialize the text on Start() instead of OnEnable()
		 * because the value isn't ready until this point in execution
		 */
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
