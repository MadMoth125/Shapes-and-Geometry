using System;
using Interfaces;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

[ExecuteInEditMode]

#endif

public class Circle : Shape, IDrawable
{
	public Circle(float radius)
	{
		this.radius = radius;
	}
	
	[Range(0.1f, 5.0f)]
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
	
	public void SetRadius(float radius)
	{
		this.radius = radius;
	}
	
	/// <summary>
	/// Get the diameter of the circle.
	/// </summary>
	/// <returns>The diameter of the circle.</returns>
	public float GetDiameter()
	{
		return radius * 2f;
	}
	
	public override float GetShapeArea()
	{
		return Mathf.PI * Mathf.Pow(radius, 2);
	}
	
	public override float GetShapePerimeter()
	{
		return 2 * Mathf.PI * radius;
	}
}
