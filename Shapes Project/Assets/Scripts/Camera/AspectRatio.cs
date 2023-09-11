using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatio : MonoBehaviour
{
	private Camera mainCamera;
	
	public Vector2 targetAspectRatio = new Vector2(16f, 9f);

	private void Awake()
	{
		mainCamera = GetComponent<Camera>();
	}

	// Start is called before the first frame update
	void Start()
	{
		if (mainCamera != null)
		{
			mainCamera.aspect = targetAspectRatio.x / targetAspectRatio.y;
		}
	}

	// Update is called once per frame
	void Update()
	{
		
		//mainCamera.orthographicSize = 5f * ((targetAspectRatio.x / targetAspectRatio.y) / mainCamera.aspect);
	}
}
