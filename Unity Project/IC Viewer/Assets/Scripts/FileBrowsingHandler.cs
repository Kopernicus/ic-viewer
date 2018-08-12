using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SFB;

[RequireComponent(typeof(Button))]
public class FileBrowsingHandler : MonoBehaviour, IPointerDownHandler
{
	public EditorManager manager;
	
	#if UNITY_WEBGL && !UNITY_EDITOR
	//
	// WebGL
	//
    [DllImport("__Internal")]
    private static extern void UploadFile(string id);

    public void OnPointerDown(PointerEventData eventData) {
        UploadFile(gameObject.name);
    }

    // Called from browser
    public void OnFileUploaded(string url) {
        StartCoroutine(OutputRoutine(url));
    }
	#else
	//
	// Standalone platforms & editor
	//
	public void OnPointerDown(PointerEventData eventData) { }

	void Start() {
		var button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}

	private void OnClick() {
		var paths = StandaloneFileBrowser.OpenFilePanel("Upload Star Database", "", "json", false);
		if (paths.Length > 0) {
			StartCoroutine(OutputRoutine(new Uri(paths[0]).AbsoluteUri));
		}
	}
	#endif

	private IEnumerator OutputRoutine(String url) {
		WWW loader = new WWW(url);
		yield return loader;
		manager.LoadBodies(loader.text);
		Logger.Info("Imported uploaded star database");
	}
}
