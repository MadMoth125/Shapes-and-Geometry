using System;
using Shapes;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class CircleParameters : ParametersBase
{
	// The shape that is being modified.
	[HideInInspector]
	public Circle circleRef;
	
	// UI elements that reference the circle's radius.
	[FormerlySerializedAs("_radiusSliderRef")] [SerializeField]
	private SliderElement radiusSliderRef;
	
	// UI elements that reference the circle's diameter.
	[SerializeField]
	private TextMeshProUGUI textDiameterRef;
	public string diameterText;
	
	// UI elements that reference general shape parameters.
	private ShapeParameters _shapeParametersRef;
	
	// subscribe to the slider's OnSliderValueChanged event.
	private void OnEnable()
	{
		// Get the shape parameters UI reference.
		_shapeParametersRef = GetComponentInChildren<ShapeParameters>();

		try
		{
			radiusSliderRef.OnSliderValueChanged += OnRadiusUpdated;
		}
		catch { Debug.LogError($"{this.name} - Slider not found!"); }
	}

	// unsubscribe from the slider's OnSliderValueChanged event.
	private void OnDestroy()
	{
		try
		{
			radiusSliderRef.OnSliderValueChanged -= OnRadiusUpdated;
		}
		catch { /* ignored */ }
	}

	private void Start()
	{
		// Cast the general shape reference to a circle reference.
		circleRef = shapeRef as Circle;
		
		if (circleRef)
		{
			/* Initialize the text on Start() instead of OnEnable()
			 * because the value isn't ready until this point in execution
			 */
			SetDiameterText(circleRef.GetDiameter());
		}
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
