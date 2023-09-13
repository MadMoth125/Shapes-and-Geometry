using System;
using UnityEngine;
using TMPro;

public class TriangleParameters : MonoBehaviour
{
	[HideInInspector]
	public Triangle triangleRef;
	
	[SerializeField] // Text element that displays the triangle's Hypotenuse
	private TextMeshProUGUI textHypotenuseRef;
	public string hypotenuseText;
	
	[SerializeField]
	private SliderElement sliderWidthRef;
	[SerializeField]
	private SliderElement sliderHeightRef;
	
	private ShapeParameters _shapeParametersRef;

	// subscribe to the slider's OnSliderValueChanged event.
	private void OnEnable()
	{
		// Get the shape parameters UI reference.
		_shapeParametersRef = GetComponentInChildren<ShapeParameters>();

		try
		{
			sliderWidthRef.OnSliderValueChanged += OnSliderWidthUpdated;
			sliderHeightRef.OnSliderValueChanged += OnSliderHeightUpdated;
		}
		catch
		{
			Debug.LogError($"{this.name} - Width OR Height slider not found!");
		}
	}

	// unsubscribe from the slider's OnSliderValueChanged event.
	private void OnDestroy()
	{
		try
		{
			sliderWidthRef.OnSliderValueChanged -= OnSliderWidthUpdated;
			sliderHeightRef.OnSliderValueChanged -= OnSliderHeightUpdated;
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
		SetHypotenuseText(triangleRef.GetHypotenuse());
	}

	private void OnSliderWidthUpdated(float newWidth)
	{
		if (!triangleRef || !_shapeParametersRef) return; // if the rectangle reference or shape script is null, return.
		
		// Update the rectangle's width.
		triangleRef.SetWidth(newWidth);
		
		// Update the hypotenuse text.
		SetHypotenuseText(triangleRef.GetHypotenuse());
		
		// Update the general shape parameters text.
		_shapeParametersRef.SetAreaText(triangleRef.GetShapeArea());
		_shapeParametersRef.SetPerimeterText(triangleRef.GetShapePerimeter());
	}
	
	private void OnSliderHeightUpdated(float newHeight)
	{
		if (!triangleRef || !_shapeParametersRef) return; // if the rectangle reference or shape script is null, return.
		
		// Update the rectangle's height.
		triangleRef.SetHeight(newHeight);
		
		// Update the hypotenuse text.
		SetHypotenuseText(triangleRef.GetHypotenuse());
		
		// Update the general shape parameters text.
		_shapeParametersRef.SetAreaText(triangleRef.GetShapeArea());
		_shapeParametersRef.SetPerimeterText(triangleRef.GetShapePerimeter());
	}

	public void SetHypotenuseText(float value)
	{
		textHypotenuseRef.text = $"{hypotenuseText} {value:F}";
	}
}
