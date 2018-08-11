using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DisplaySOI : MonoBehaviour
{
	/// <summary>
	/// Whether to show SOIs
	/// </summary>
	public static Boolean ShowSOI;
	
	/// <summary>
	/// The SOI that should get displayed
	/// </summary>
	public Single SphereOfInfluence;

	/// <summary>
	/// The internal representation of the GL material
	/// </summary>
	private static Material _material;

	/// <summary>
	/// Gets or sets the used GL material.
	/// </summary>
	/// <value>
	/// The material.
	/// </value>
	public static Material Material
	{
		get
		{
			if (_material == null)
				_material = new Material(Shader.Find("Particles/Additive"));
			return _material;
		}
		set { _material = value; }
	}
	
	void Start ()
	{
		// Setup Renderer
		DrawCircle(Vector3.up, Vector3.right);
		DrawCircle(Vector3.forward, Vector3.up);
		DrawCircle(Vector3.right, Vector3.forward);
	}

	/// <summary>
	/// Setups a line renderer to draw a circle around the given axis
	/// </summary>
	private void DrawCircle(Vector3 direction, Vector3 euler)
	{
		GameObject lineRendererObj = new GameObject();
		lineRendererObj.transform.parent = transform;
		lineRendererObj.transform.localPosition = Vector3.zero;
		LineRenderer lineRenderer = lineRendererObj.AddComponent<LineRenderer>();
		lineRenderer.positionCount = 36;
		lineRenderer.widthMultiplier = 0.05f;
		lineRenderer.useWorldSpace = false;
		lineRenderer.startColor = lineRenderer.endColor = new Color32(58, 162, 239, 255);
		if (Body.bodies.Any(b => b != gameObject &&
			Vector3.Distance(b.transform.position, transform.position) <
			SphereOfInfluence + b.GetComponent<DisplaySOI>().SphereOfInfluence))
		{
			// The two SOIs are intersecting, color them red
			lineRenderer.startColor = lineRenderer.endColor = Color.red;
		}
		lineRenderer.material = Material;
		lineRenderer.loop = true;
		
		Vector3 soi = direction * SphereOfInfluence;
		for (Int32 i = 0; i < 36; i++)
		{
			lineRenderer.SetPosition(i,
				Quaternion.Euler(euler.x * i * 10, euler.y * i * 10, euler.z * i * 10) * soi);
		}
		
	}

	void Update()
	{
		foreach (Transform t in transform)
		{
			t.rotation = Quaternion.identity;
			t.gameObject.SetActive(ShowSOI);
		}
	}
}
