using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways]
public class CameraAspectRatio : MonoBehaviour
{
	public float targetAspectRatio = 4.0f / 3.0f; // Default to 4:3 aspect ratio
	private float previousAspectRatio;
	
	private Camera mainCamera;
	private Rect rect;
	
	private void Awake()
	{
		mainCamera = GetComponent<Camera>();
		Debug.Log("Found main camera: " + mainCamera.name);
	}
	
	private void Start()
	{
		
	}

	private void Update()
	{
		if (targetAspectRatio != previousAspectRatio)
		{
			UpdateAspectRatio();
		}
	}

	private void UpdateAspectRatio()
	{
		if (mainCamera != null)
		{
			Debug.Log("Updating aspect ratio");
			float currentAspectRatio = (float)Screen.width / Screen.height;
			float scaleHeight = currentAspectRatio / targetAspectRatio;

			rect = mainCamera.rect;

			if (scaleHeight < 1)
			{
				rect.width = 1;
				rect.height = scaleHeight;
				rect.x = 0;
				rect.y = (1 - scaleHeight) / 2;
			}
			else
			{
				rect.width = 1 / scaleHeight;
				rect.height = 1;
				rect.x = (1 - 1 / scaleHeight) / 2;
				rect.y = 0;
			}

			mainCamera.rect = rect;
			previousAspectRatio = targetAspectRatio;
		}
	}
}
