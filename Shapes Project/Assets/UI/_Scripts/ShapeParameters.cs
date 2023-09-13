using System;
using UnityEngine;
using TMPro;

public class ShapeParameters : ParametersBase
{
	[Header("Perimeter Settings")]
	public string areaText;
	[SerializeField]
	private TextMeshProUGUI textAreaRef;
	
	[Header("Perimeter Settings")]
	public string perimeterText;
	[SerializeField]
	private TextMeshProUGUI textPerimeterRef;
	
	public void SetAreaText(float value)
	{
		if (!textAreaRef) return;
		
		textAreaRef.text = $"{areaText} {value:F}";
	}
	
	public void SetPerimeterText(float value)
	{
		if (!textPerimeterRef) return;
		
		textPerimeterRef.text = $"{perimeterText} {value:F}";
	}
}
