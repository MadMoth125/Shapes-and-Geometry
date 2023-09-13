using System;
using UnityEngine;

namespace _Scripts
{
    [Serializable]
    public struct ShapeStruct
    {
        public GameObject ShapePrefab;
        public GameObject UserInterfacePrefab;
        
        public ShapeStruct(GameObject shapePrefab, GameObject userInterfacePrefab)
        {
            ShapePrefab = shapePrefab;
            UserInterfacePrefab = userInterfacePrefab;
        }
    }
}