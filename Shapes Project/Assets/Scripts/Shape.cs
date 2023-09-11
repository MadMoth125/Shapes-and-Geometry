using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
	public float Area { get; protected set; }
	public float Perimeter { get; protected set; }
	
	public Shape() { }
	
	public virtual float CalculateArea()
	{
		return 0;
	}
	
	public virtual float CalculatePerimeter()
	{
		return 0;
	}
}
