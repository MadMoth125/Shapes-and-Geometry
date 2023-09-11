using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : Shape
{
	public float SideLengthA { get; private set; }
	public float SideLengthB { get; private set; }
	public float SideLengthC { get; private set; }
	
	public Triangle(float sideLengthA, float sideLengthB, float sideLengthC)
	{
		SideLengthA = sideLengthA;
		SideLengthB = sideLengthB;
		SideLengthC = sideLengthC;
	}
	
	public override float CalculateArea()
	{
		float s = (SideLengthA + SideLengthB + SideLengthC) / 2;
		Area = Mathf.Sqrt(s * (s - SideLengthA) * (s - SideLengthB) * (s - SideLengthC));
		return Area;
	}
	
	public override float CalculatePerimeter()
	{
		Perimeter = SideLengthA + SideLengthB + SideLengthC;
		return Perimeter;
	}
}
