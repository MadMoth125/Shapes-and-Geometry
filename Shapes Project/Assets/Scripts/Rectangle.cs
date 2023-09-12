using System;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

[ExecuteInEditMode]

#endif

[RequireComponent(typeof(SpriteRenderer))]
public class Rectangle : Shape
{
    public Rectangle(float width, float height)
    {
        this.width = width;
        this.height = height;
    }
    
    [Range(0.1f, 10.0f)]
    public float width;
    [Range(0.1f, 10.0f)]
    public float height;
    
    private float _previousWidth;
    private float _previousHeight;

    private bool ShouldUpdate => height != _previousHeight || width != _previousWidth;
    
    private void Update()
    {
        if (ShouldUpdate)
        {
            _previousWidth = width;
            _previousHeight = height;
            
            transform.localScale = new Vector3(width, height, 1f);
        }
    }

    public override float GetShapeArea()
    {
        return height * width;
    }
    
    public override float GetShapePerimeter()
    {
        return 2 * (height + width);
    }
}
