using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WebGLBuilder 
{
	/// <summary>
	/// Allows us to compile the project using the commandline
	/// </summary>
	public static void Build() 
	{
		const String pathToDeploy = "build/ic-viewer";
		
		// Collect all scenes that should get built
		String[] scenes = new String[SceneManager.sceneCountInBuildSettings];
		for (Int32 i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
		{
			scenes[i] = SceneUtility.GetScenePathByBuildIndex(i);
		}

		BuildPipeline.BuildPlayer(new BuildPlayerOptions()
		{
			assetBundleManifestPath = "ic-viewer",
			locationPathName = pathToDeploy,
			options = BuildOptions.None,
			scenes = scenes,
			target = BuildTarget.WebGL,
			targetGroup = BuildTargetGroup.WebGL
		});   
	}
}
