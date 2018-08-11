using System;
using UnityEditor;
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
		for (Int32 i = 0; i < scenes.Length; i++)
		{
			scenes[i] = SceneManager.GetSceneByBuildIndex(i).path;
		}

		BuildPipeline.BuildPlayer(scenes, pathToDeploy, BuildTarget.WebGL, BuildOptions.None);      
	}
}
