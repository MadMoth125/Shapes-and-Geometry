using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
	[SerializeField] private Transform shapePosition;
	
	private GameObject _currentShape;
	private GameObject _savedObject;
	[SerializeField] private GameObject[] shapePrefabs;
	
	
	
	public void OnCircleSelected()
	{
		if (shapePrefabs.Length == 0)
		{
			Debug.LogError("No shape prefabs assigned to ShapeManager!");
			return;
		}

		GameObject circlePrefab = FindPrefab("CustomCircle");

		if (_currentShape == circlePrefab)
		{
			return; // No need to instantiate if it's already the selected shape
		}

		_currentShape = circlePrefab;

		if (_currentShape != null)
		{
			Destroy(_savedObject);
			_savedObject = Instantiate(_currentShape, shapePosition.position, shapePosition.rotation);
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

		GameObject rectanglePrefab = FindPrefab("CustomRectangle");

		if (_currentShape == rectanglePrefab)
		{
			return; // No need to instantiate if it's already the selected shape
		}

		_currentShape = rectanglePrefab;

		if (_currentShape != null)
		{
			Destroy(_savedObject);
			_savedObject = Instantiate(_currentShape, shapePosition.position, shapePosition.rotation);
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

		GameObject trianglePrefab = FindPrefab("CustomTriangle");

		if (_currentShape == trianglePrefab)
		{
			return; // No need to instantiate if it's already the selected shape
		}

		_currentShape = trianglePrefab;

		if (_currentShape != null)
		{
			Destroy(_savedObject);
			_savedObject = Instantiate(_currentShape, shapePosition.position, shapePosition.rotation);
		}
		else
		{
			Debug.LogError("Could not find prefab with name \"CustomTriangle\"!");
		}
	}

	#region Prefab Searching
	private bool FindPrefab(string prefabName, out GameObject prefab)
	{
		prefab = shapePrefabs.FirstOrDefault(shapePrefab => shapePrefab.name == prefabName);
		return prefab != null;
	}
	
	private GameObject FindPrefab(string prefabName)
	{
		return shapePrefabs.FirstOrDefault(shapePrefab => shapePrefab.name == prefabName);
	}
	#endregion
}
