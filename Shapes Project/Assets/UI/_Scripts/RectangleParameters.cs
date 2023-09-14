using System;
using Shapes;
using UnityEngine;
using TMPro;

public class RectangleParameters : ParametersBase
{
	// The shape that is being modified.
	[HideInInspector]
	public Rectangle rectangleRef;
	
	// UI elements that reference the rectangle's width/height.
	[SerializeField]
	private SliderElement sliderWidthRef;
	[SerializeField]
	private SliderElement sliderHeightRef;
	
	// UI elements that reference general shape parameters.
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
		catch { Debug.LogError($"{this.name} - Width OR Height slider not found!"); }
	}

	// unsubscribe from the slider's OnSliderValueChanged event.
	private void OnDestroy()
	{
		try
		{
			sliderWidthRef.OnSliderValueChanged -= OnSliderWidthUpdated;
			sliderHeightRef.OnSliderValueChanged -= OnSliderHeightUpdated;
		}
		catch { /* ignored */ }
	}

	private void Start()
	{
		// Cast the general shape reference to a rectangle reference.
		rectangleRef = shapeRef as Rectangle;
	}

	private void OnSliderWidthUpdated(float newWidth)
	{
		try
		{
			// Update the rectangle's width.
			rectangleRef.SetWidth(newWidth);
		
			// Update the general shape parameters text.
			_shapeParametersRef.SetAreaText(rectangleRef.GetShapeArea());
			_shapeParametersRef.SetPerimeterText(rectangleRef.GetShapePerimeter());
		}
		catch { /* ignored */ }
	}

	private void OnSliderHeightUpdated(float newHeight)
	{
		try
		{
			// Update the rectangle's height.
			rectangleRef.SetHeight(newHeight);

			// Update the general shape parameters text.
			_shapeParametersRef.SetAreaText(rectangleRef.GetShapeArea());
			_shapeParametersRef.SetPerimeterText(rectangleRef.GetShapePerimeter());
		}
		catch { /* ignored */ }
	}
}
