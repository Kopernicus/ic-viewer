using System;
using System.Collections.Generic;
using System.Net;
using SFB;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    public Sprite testBodySprite, shadowSprite, raySprite;

    public const String DatabaseUrl = "https://rawgit.com/Kopernicus/interstellar-consortium/master/database.json";

    void Start()
    {
        // Autoload the online version of the database
        WWW www = new WWW(DatabaseUrl);
        while (!www.isDone)
        {
            // Wait until the download finished
        }
        LoadBodies(www.text);
    }
    
    public void LoadBodies(String json)
    {
        GameBody.DestroyAllBodies();

        BodyList bl = JSONLoader.LoadStars(json);
        List<GameObject> gos = Body.LoadBodiesInGame(bl, testBodySprite, shadowSprite, raySprite);

        GameObject tempParentGo = GameObject.Find("Bodies");
        foreach (GameObject go in gos)
        {
            go.transform.SetParent(tempParentGo.transform);
        }
    }

    public void ToggleSOIDisplay()
    {
        DisplaySOI.ShowSOI = !DisplaySOI.ShowSOI;
    }

    public static void VoidTemporaryGameObject()
    {
        foreach(Transform c in GameObject.Find("Temporary").transform)
        {
            Destroy(c.gameObject);
        }
    }
}
