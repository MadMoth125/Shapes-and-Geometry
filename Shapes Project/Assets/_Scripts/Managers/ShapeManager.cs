using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using _Scripts;
using UnityEngine.Serialization;

public class ShapeManager : MonoBehaviour
{
	public delegate void ShapeSelect(ShapeStruct selectedShape);
	public event ShapeSelect OnShapeSelected;
	
	[SerializeField]
	private ShapeStruct[] shapePrefabs;
	
	private ShapeStruct _activeShape;
	
	[SerializeField]
	private Transform shapePosition, uiPosition;

	private GameObject _currentShape, _currentUI;

	private GameObject _savedObject, _savedUI;
	
	public void OnCircleSelected()
	{
		if (!IsValidLength()) return;

		AttemptCreateShape("CustomCircle", out _activeShape);
		
		_savedUI.GetComponent<CircleParameters>().circleRef = _savedObject.GetComponent<Circle>();
		
	}

	public void OnRectangleSelected()
	{
		if (!IsValidLength()) return;

		AttemptCreateShape("CustomRectangle", out _activeShape);
		
		_savedUI.GetComponent<RectangleParameters>().rectangleRef = _savedObject.GetComponent<Rectangle>();
		
		// TODO: Set the rectangle's parameters.
		//_savedUI.GetComponent<CircleParameters>().circleRef = _savedObject.GetComponent<Circle>();
	}
	
	public void OnTriangleSelected()
	{
		if (!IsValidLength()) return;

		AttemptCreateShape("CustomTriangle", out _activeShape);
		
		// TODO: Set the triangle's parameters.
		// _savedUI.GetComponent<CircleParameters>().circleRef = _savedObject.GetComponent<Circle>();
	}

	#region Prefab Searching
	private bool FindPrefab(string prefabName, out ShapeStruct prefab)
	{
		prefab = shapePrefabs.FirstOrDefault(tempPrefab => tempPrefab.ShapePrefab.name == prefabName);
		return prefab.ShapePrefab != null;
	}
	
	private ShapeStruct FindPrefab(string prefabName)
	{
		return shapePrefabs.FirstOrDefault(tempPrefab => tempPrefab.ShapePrefab.name == prefabName);
	}
	#endregion

	private void AttemptCreateShape(string shapeName, out ShapeStruct shapeStructure)
	{
		shapeStructure = FindPrefab(shapeName);
		
		if (_currentShape == shapeStructure.ShapePrefab)
		{
			return; // No need to instantiate if it's already the selected shape
		}

		_currentShape = shapeStructure.ShapePrefab;
		_currentUI = shapeStructure.UserInterfacePrefab;
		
		if (_currentShape)
		{
			// Destroy the old shape and UI.
			Destroy(_savedObject);
			Destroy(_savedUI);
			
			// Attempt to instantiate the new shape and UI.
			try
			{
				// _savedObject = Instantiate(_currentShape, shapePosition, false);
				_savedObject = Instantiate(_currentShape, shapePosition.position, shapePosition.rotation, shapePosition);
			}
			catch
			{
				// If the instantiation fails, log an error.
				Debug.LogError($"{this.name} - Could not instantiate shape!");
			}

			try
			{
				_savedUI = Instantiate(_currentUI, uiPosition);
			}
			catch
			{
				// If the instantiation fails, log an error.
				Debug.LogError($"{this.name} - Could not instantiate shape UI!");
			}
			
			OnShapeSelected?.Invoke(shapeStructure);
		}
		else
		{
			Debug.LogError($"Could not find prefab with name \"{shapeName}\"!");
		}
	}
	
	private bool IsValidLength()
	{
		if (shapePrefabs.Length == 0)
		{
			Debug.LogError("No shape prefabs assigned to ShapeManager!");
			return false;
		}

		return true;
	}
}
