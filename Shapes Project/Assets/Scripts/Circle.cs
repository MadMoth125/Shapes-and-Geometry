using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Shape
{
	public float Radius { get; private set; }
	
	public Circle(float radius)
	{
		Radius = radius;
	}
	
	public override float CalculateArea()
	{
		Area = Mathf.PI * Mathf.Pow(Radius, 2);
		return Area;
	}
	
	public override float CalculatePerimeter()
	{
		Perimeter = 2 * Mathf.PI * Radius;
		return Perimeter;
	}
}
