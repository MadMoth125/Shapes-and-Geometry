using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class RectangleParameters : ParametersBase
{
	[HideInInspector]
	public Rectangle rectangleRef;
	
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

	private void OnSliderWidthUpdated(float newWidth)
	{
		if (!rectangleRef || !_shapeParametersRef) return; // if the rectangle reference or shape script is null, return.
		
		// Update the rectangle's width.
		rectangleRef.SetWidth(newWidth);
		
		// Update the general shape parameters text.
		_shapeParametersRef.SetAreaText(rectangleRef.GetShapeArea());
		_shapeParametersRef.SetPerimeterText(rectangleRef.GetShapePerimeter());
	}
	
	private void OnSliderHeightUpdated(float newHeight)
	{
		if (!rectangleRef || !_shapeParametersRef) return; // if the rectangle reference or shape script is null, return.
		
		// Update the rectangle's height.
		rectangleRef.SetHeight(newHeight);
		
		// Update the general shape parameters text.
		_shapeParametersRef.SetAreaText(rectangleRef.GetShapeArea());
		_shapeParametersRef.SetPerimeterText(rectangleRef.GetShapePerimeter());
	}
}
