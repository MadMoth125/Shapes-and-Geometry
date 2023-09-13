using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using _Scripts;

public class ShapeManager : MonoBehaviour
{
	public delegate void ShapeSelect(ShapeStruct selectedShape);
	public event ShapeSelect OnShapeSelected;
	
	[SerializeField] private ShapeStruct[] shapePrefabs;
	[SerializeField] private Transform shapePosition;

	private GameObject _currentShape;
	private GameObject _savedObject;

	private ShapeStruct _activeShape;
	
	public void OnCircleSelected()
	{
		if (!IsValidLength()) return;

		AttemptCreateShape("CustomCircle", out _activeShape);
	}

	public void OnRectangleSelected()
	{
		if (!IsValidLength()) return;

		AttemptCreateShape("CustomRectangle", out _activeShape);
	}
	
	public void OnTriangleSelected()
	{
		if (!IsValidLength()) return;

		AttemptCreateShape("CustomTriangle", out _activeShape);
		
		
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

		if (_currentShape != null)
		{
			Destroy(_savedObject);
			// _savedObject = Instantiate(_currentShape, shapePosition, true);
			_savedObject = Instantiate(_currentShape, shapePosition.position, shapePosition.rotation, shapePosition);
			
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
