using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
	/// <summary>
	/// The area of the shape.
	/// </summary>
	public float Area { get; protected set; }
	
	/// <summary>
	/// The perimeter of the shape.
	/// </summary>
	public float Perimeter { get; protected set; }
	
	public Shape() { }
	
	/// <summary>
	/// Calculates and returns the area of the shape.
	/// </summary>
	/// <returns>The area of the shape.</returns>
	public virtual float GetShapeArea()
	{
		return 0;
	}
	
	/// <summary>
	/// Calculates and returns the perimeter of the shape.
	/// </summary>
	/// <returns>The area of the perimeter.</returns>
	public virtual float GetShapePerimeter()
	{
		return 0;
	}
}
