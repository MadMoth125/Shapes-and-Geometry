using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private ShapeManager shapeManager;

    private void OnEnable()
    {
        shapeManager.OnShapeSelect += OnShapeSelect;
    }

    private void OnShapeSelect(ShapeStruct selectedShape)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
