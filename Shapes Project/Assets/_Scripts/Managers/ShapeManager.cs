using System.Collections;
using UnityEngine;
using Shapes;

public class ShapeManager : MonoBehaviour
{
	public delegate void ShapeSelect(ShapeStruct selectedShape);
	public event ShapeSelect OnShapeSelected;

	[SerializeField]
	private ShapeStruct[] shapePrefabs;
	private ShapeStruct _current;
	private ShapeStruct _selected;
	
	[SerializeField]
	private Transform shapeTransform;
	[SerializeField]
	private Transform uiTransform;
	
	public void OnCircleSelected()
	{
		if (!IsValidLength()) return;

		_selected = FindPrefab<Circle>();

		// No need to instantiate if it's already the selected shape
		if (_selected.prefab is Circle && _current.prefab is Circle) return;
		
		StartCoroutine(CreateShapeCoroutine());
	}

	public void OnRectangleSelected()
	{
		if (!IsValidLength()) return;

		_selected = FindPrefab<Rectangle>();

		// No need to instantiate if it's already the selected shape
		if (_selected.prefab is Rectangle && _current.prefab is Rectangle) return;
		
		StartCoroutine(CreateShapeCoroutine());
	}
	
	public void OnTriangleSelected()
	{
		if (!IsValidLength()) return;

		_selected = FindPrefab<Triangle>();

		// No need to instantiate if it's already the selected shape
		if (_selected.prefab is Triangle && _current.prefab is Triangle) return;
		
		StartCoroutine(CreateShapeCoroutine());
	}

	#region Shape Instantiation
	/// <summary>
	/// Creates the shape/UI element based on _currentShape. Handles removing the old shape and UI element when necessary.
	/// </summary>
	private void CreateShape()
	{
		// Destroy the old shape and UI if they are still present.
		if (_current.prefab)
		{
			Destroy(_current.prefab.gameObject);
			Destroy(_current.ui.gameObject);
		}

		// Attempt to instantiate the new shape and UI.
		try
		{
			_current.prefab = Instantiate(_selected.prefab, shapeTransform.position, shapeTransform.rotation, shapeTransform);
			
			// alternate way to instantiate, prone to breaking
			// _savedObject = Instantiate(_currentShape, shapePosition, false);
		}
		catch { Debug.LogError($"{this.name} - Could not instantiate shape!"); }

		try
		{
			_current.ui = Instantiate(_selected.ui, uiTransform);
			_current.ui.shapeRef = _current.prefab;
		}
		catch { Debug.LogError($"{this.name} - Could not instantiate shape UI!"); }
			
		OnShapeSelected?.Invoke(_current);
	}
	
	/// <summary>
	/// Coroutine version of <see cref="CreateShape"/>
	/// </summary>
	/// <returns></returns>
	private IEnumerator CreateShapeCoroutine()
	{
		// Destroy the old shape and UI if they are still present.
		if (_current.prefab)
		{
			Destroy(_current.prefab.gameObject);
			Destroy(_current.ui.gameObject);
			yield return new WaitForEndOfFrame();
		}

		// Attempt to instantiate the new shape and UI.
		try
		{
			_current.prefab = Instantiate(_selected.prefab, shapeTransform.position, shapeTransform.rotation, shapeTransform);
			
			// alternate way to instantiate, prone to breaking
			// _savedObject = Instantiate(_currentShape, shapePosition, false);
		}
		catch { Debug.LogError($"{this.name} - Could not instantiate shape!"); }
		
		yield return new WaitForEndOfFrame();
		
		try
		{
			_current.ui = Instantiate(_selected.ui, uiTransform);
			_current.ui.shapeRef = _current.prefab;
		}
		catch { Debug.LogError($"{this.name} - Could not instantiate shape UI!"); }
			
		OnShapeSelected?.Invoke(_current);
	}
	#endregion
	
	#region Helpers
	/// <summary>
	/// Searches <see cref="shapePrefabs"/> for a prefab with the type <typeparamref name="T"/>.
	/// </summary>
	/// <typeparam name="T">Specified class that derives from <see cref="Shape"/></typeparam>
	/// <returns>The corresponding shape struct if the prefab is found.</returns>
	private ShapeStruct FindPrefab<T>() where T : Shape
	{
		foreach (var shape in shapePrefabs)
		{
			if (shape.prefab is T component)
			{
				return shape;
			}
		}

		return new ShapeStruct(); // Return null if the component is not found.
	}
	
	/// <summary>
	/// Checks if the length of <see cref="shapePrefabs"/> is greater than 0.
	/// </summary>
	/// <returns></returns>
	private bool IsValidLength()
	{
		if (shapePrefabs.Length == 0)
		{
			Debug.LogError("No shape prefabs assigned to ShapeManager!");
			return false;
		}

		return true;
	}
	#endregion
}