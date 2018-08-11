using System;
using System.Collections.Generic;
using System.Net;
using SFB;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    public Sprite testBodySprite, shadowSprite, raySprite;

    /// <summary>
    /// SCRIPTING COLOR SETTER
    /// </summary>
    public static ColorManagerSetter colorManagerSetter;

    public Color mainColor, secondaryColor, thirdColor;
    public bool forceRuntimeUpdate = true;

    public const String DatabaseUrl = "https://rawgit.com/Kopernicus/interstellar-consortium/master/database.json";

    void Start()
    {
        colorManagerSetter = gameObject.AddComponent<ColorManagerSetter>(
            //mainColor,      //0.839f, 0.278f, 0, 1
            //secondaryColor, //0, 0.223f, 0.580f, 1
            /*thirdColor*/);    //0.502f, 0.502f, 0.502f, 1

        // Autoload the online version of the database
        WWW www = new WWW(DatabaseUrl);
        while (!www.isDone)
        {
            // Wait until the download finished
        }
        LoadBodies(www.text);
    }

    public void Update()
    {
        colorManagerSetter.update = forceRuntimeUpdate;

        colorManagerSetter.MainColor = mainColor;
        colorManagerSetter.SecondaryColor = secondaryColor;
        colorManagerSetter.ThirdColor = thirdColor;
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
