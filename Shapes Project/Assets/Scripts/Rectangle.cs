using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

[ExecuteInEditMode]

#endif

[RequireComponent(typeof(SpriteRenderer))]
public class Rectangle : Shape
{
    public float length;
    public float width;
    
    private float _previousLength;
    private float _previousWidth;
    
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite sprite;
    
    public Rectangle(float length, float width)
    {
        this.length = length;
        this.width = width;
    }

    private void Update()
    {
        if (_previousLength != length || _previousWidth != width)
        {
            transform.localScale = new Vector3(length, width, 1f);
            _previousLength = length;
            _previousWidth = width;
        }
    }

    public override float GetShapeArea()
    {
        Area = length * width;
        return Area;
    }
    
    public override float GetShapePerimeter()
    {
        Perimeter = 2 * (length + width);
        return Perimeter;
    }
}
