using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle : Shape
{
    public float Length { get; private set; }
    public float Width { get; private set; }
    
    public Rectangle(float length, float width)
    {
        Length = length;
        Width = width;
    }
    
    public override float GetShapeArea()
    {
        Area = Length * Width;
        return Area;
    }
    
    public override float GetShapePerimeter()
    {
        Perimeter = 2 * (Length + Width);
        return Perimeter;
    }
}
