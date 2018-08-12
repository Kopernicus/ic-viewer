using System;
using UnityEngine;

public class PanelSlider : MonoBehaviour
{
	public Single EnabledSpeed;
	public Single DisabledSpeed;

	public GameObject EnabledPanel;
	public GameObject DisabledPanel;

	private Vector3 _enabledPosition;
	private Vector3 _disabledPostion;

	void Start()
	{
		_enabledPosition = EnabledPanel.transform.position;
		_disabledPostion = DisabledPanel.transform.position;
	}
	
	public void TogglePanel()
	{
		_enabledPosition = DisabledPanel.transform.position;
		_disabledPostion = EnabledPanel.transform.position;
	}
	
	void Update () 
	{
		if (!(EnabledPanel.transform.position == _enabledPosition))
		{
			EnabledPanel.transform.position = Vector3.Lerp(EnabledPanel.transform.position, _enabledPosition,
				EnabledSpeed * Time.deltaTime);
		}

		if (!(DisabledPanel.transform.position == _disabledPostion))
		{
			DisabledPanel.transform.position = Vector3.Lerp(DisabledPanel.transform.position, _disabledPostion,
				DisabledSpeed * Time.deltaTime);
		}
	}
}
