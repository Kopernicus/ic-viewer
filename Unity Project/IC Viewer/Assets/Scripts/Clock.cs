using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
	private TextMeshProUGUI _text;

	public String Format = "HH : mm : ss";
	
	void Start ()
	{
		_text = GetComponent<TextMeshProUGUI>();
	}
	
	void Update ()
	{
		_text.text = DateTime.Now.ToString(Format);
	}
}
