using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using _Scripts;

public class ShapeManager : MonoBehaviour
{
	public delegate void ShapeSelect(ShapeStruct selectedShape);
	public event ShapeSelect OnShapeSelect;
	
	[SerializeField] private ShapeStruct[] shapePrefabs;
	[SerializeField] private Transform shapePosition;

	private GameObject _currentShape;
	private GameObject _savedObject;
	
	public void OnCircleSelected()
	{
		if (shapePrefabs.Length == 0)
		{
			Debug.LogError("No shape prefabs assigned to ShapeManager!");
			return;
		}

		ShapeStruct tempPrefab = FindPrefab("CustomCircle");

		if (_currentShape == tempPrefab.ShapePrefab)
		{
			return; // No need to instantiate if it's already the selected shape
		}

		_currentShape = tempPrefab.ShapePrefab;

		if (_currentShape != null)
		{
			Destroy(_savedObject);
			_savedObject = Instantiate(_currentShape, shapePosition.position, shapePosition.rotation);
			
			OnShapeSelect?.Invoke(tempPrefab);
		}
		else
		{
			Debug.LogError("Could not find prefab with name \"CustomCircle\"!");
		}
	}

	public void OnRectangleSelected()
	{
		if (shapePrefabs.Length == 0)
		{
			Debug.LogError("No shape prefabs assigned to ShapeManager!");
			return;
		}

		ShapeStruct tempPrefab = FindPrefab("CustomRectangle");

		if (_currentShape == tempPrefab.ShapePrefab)
		{
			return; // No need to instantiate if it's already the selected shape
		}

		_currentShape = tempPrefab.ShapePrefab;

		if (_currentShape != null)
		{
			Destroy(_savedObject);
			_savedObject = Instantiate(_currentShape, shapePosition.position, shapePosition.rotation);
			
			OnShapeSelect?.Invoke(tempPrefab);
		}
		else
		{
			Debug.LogError("Could not find prefab with name \"CustomRectangle\"!");
		}
	}
	
	public void OnTriangleSelected()
	{
		if (shapePrefabs.Length == 0)
		{
			Debug.LogError("No shape prefabs assigned to ShapeManager!");
			return;
		}

		ShapeStruct tempPrefab = FindPrefab("CustomTriangle");

		if (_currentShape == tempPrefab.ShapePrefab)
		{
			return; // No need to instantiate if it's already the selected shape
		}

		_currentShape = tempPrefab.ShapePrefab;

		if (_currentShape != null)
		{
			Destroy(_savedObject);
			_savedObject = Instantiate(_currentShape, shapePosition.position, shapePosition.rotation);
			
			OnShapeSelect?.Invoke(tempPrefab);
		}
		else
		{
			Debug.LogError("Could not find prefab with name \"CustomTriangle\"!");
		}
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
}
