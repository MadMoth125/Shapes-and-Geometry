using System;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

[ExecuteInEditMode]

#endif

public class Circle : Shape
{
	public Circle(float radius)
	{
		this.radius = radius;
	}
	
	public float radius;
	private float _previousRadius;
	
	private bool ShouldUpdate => radius != _previousRadius;
	
	private void Update()
	{
		if (ShouldUpdate)
		{
			_previousRadius = radius;
			
			transform.localScale = new Vector3(radius * 2f, radius * 2f, 1f);
		}
	}
	
	public override float GetShapeArea()
	{
		Area = Mathf.PI * Mathf.Pow(radius, 2);
		return Area;
	}
	
	public override float GetShapePerimeter()
	{
		Perimeter = 2 * Mathf.PI * radius;
		return Perimeter;
	}
}
