using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CircleParams : MonoBehaviour
{
	[SerializeField] private Slider radiusSlider;

	private void OnShapeSelect(ShapeStruct selectedShape)
	{
		if (selectedShape.ShapePrefab == null) return;
		// if (selectedShape.ShapePrefab == null || selectedShape.UserInterfacePrefab == null) return;

	}
}
