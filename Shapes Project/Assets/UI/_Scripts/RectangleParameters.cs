using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class RectangleParameters : MonoBehaviour
{
	[HideInInspector]
	public Rectangle rectangleRef;

	[SerializeField]
	private TextMeshProUGUI textWidthRef;
	[SerializeField]
	private SliderElement sliderWidthRef;

	[SerializeField]
	private SliderElement sliderHeightRef;
	
	private ShapeParameters _shapeParametersRef;
	
	private void OnEnable()
	{
		// Get the shape parameters UI reference.
		_shapeParametersRef = GetComponentInChildren<ShapeParameters>();
		
		if (!sliderWidthRef)
		{
			Debug.LogError($"{this.name} - Width slider not found!");
		}
		else
		{
			sliderWidthRef.OnSliderValueChanged += OnSliderWidthUpdated;
		}

		if (!sliderHeightRef)
		{
			Debug.LogError($"{this.name} - Height slider not found!");
		}
		else
		{
			sliderHeightRef.OnSliderValueChanged += OnSliderHeightUpdated;
		}
	}

	private void OnDestroy()
	{
		if (!sliderWidthRef || !sliderWidthRef) return;
		
		sliderWidthRef.OnSliderValueChanged -= OnSliderWidthUpdated;
		sliderHeightRef.OnSliderValueChanged -= OnSliderHeightUpdated;
	}

	private void OnSliderWidthUpdated(float newWidth)
	{
		if (!rectangleRef || !_shapeParametersRef) return; // if the rectangle reference or shape script is null, return.
		
		// Update the circle's radius.
		rectangleRef.SetWidth(newWidth);
		
		// Update the general shape parameters text.
		_shapeParametersRef.SetAreaText(rectangleRef.GetShapeArea());
		_shapeParametersRef.SetPerimeterText(rectangleRef.GetShapePerimeter());
	}
	
	private void OnSliderHeightUpdated(float newHeight)
	{
		if (!rectangleRef || !_shapeParametersRef) return; // if the rectangle reference or shape script is null, return.
		
		// Update the circle's radius.
		rectangleRef.SetHeight(newHeight);
		
		// Update the general shape parameters text.
		_shapeParametersRef.SetAreaText(rectangleRef.GetShapeArea());
		_shapeParametersRef.SetPerimeterText(rectangleRef.GetShapePerimeter());
	}
}
