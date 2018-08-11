using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    public Sprite testBodySprite, shadowSprite, raySprite;

    private string path;

    private void OnGUI()
    {
        GUILayout.BeginVertical();

        GUILayout.Label("JSON File path", GUILayout.Width(220));
        path = GUILayout.TextField(path, GUILayout.Width(220));
        GUILayout.Label("");

        if(GUILayout.Button("Load Stars", GUILayout.Width(220)))
        {
            GameBody.DestroyAllBodies();

            BodyList bl = JSONLoader.LoadStarsInFile(path);
            List<GameObject> gos = Body.LoadBodiesInGame(bl, testBodySprite, shadowSprite, raySprite);

            GameObject tempParentGo = GameObject.Find("Bodies");
            foreach (GameObject go in gos)
            {
                go.transform.SetParent(tempParentGo.transform);
            }
        }
        GUILayout.EndVertical();
    }
}
