using System;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
	private Text _text;

	public String Format = "HH : mm : ss";
	
	void Start ()
	{
		_text = GetComponent<Text>();
	}
	
	void Update ()
	{
		_text.text = DateTime.Now.ToString(Format);
	}
}
