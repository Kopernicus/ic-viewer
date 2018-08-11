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
		const String pathToDeploy = "build/";
		
		// Collect all scenes that should get built
		String[] scenes = new String[SceneManager.sceneCountInBuildSettings];
		for (Int32 i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
		{
			scenes[i] = SceneUtility.GetScenePathByBuildIndex(i);
		}

		BuildPipeline.BuildPlayer(scenes, pathToDeploy, BuildTarget.WebGL, BuildOptions.None);      
	}
}
