using System;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class CircleParameters : MonoBehaviour
{
	[HideInInspector]
	public Circle circleRef;
	
	[SerializeField]
	private TextMeshProUGUI textDiameterRef;
	
	public string diameterText = "Circle Diameter:";
	
	private void OnEnable()
	{
		//textDiameterRef = GetComponentInChildren<TextMeshProUGUI>();
		//if (textDiameterRef == null) Debug.LogError("Text not found!");
	}

	// Start is called before the first frame update
	void Start()
	{
		OnDiameterUpdated(1.0f);
	}
	
	public void OnDiameterUpdated(float value)
	{
		textDiameterRef.text = $"{diameterText} {value:F}";
		Debug.Log("Diameter updated!");
	}
}
