using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shapes
{
	[Serializable]
	public struct ShapeStruct
	{
		public Shape prefab;
		public ParametersBase ui;
		
		public ShapeStruct(Shape prefab, ParametersBase ui)
		{
			this.prefab = prefab;
			this.ui = ui;
		}
	}
}