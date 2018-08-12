using System;
using System.Collections;
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
    private bool forceRuntimeUpdate = true;

    public Font globalFont;

    public const String DatabaseUrl = "https://rawgit.com/Kopernicus/interstellar-consortium/master/database.json";

    public static float minFadeDistanceEnd = 0.2f, minFadeDistanceStart = 0.4f,
                        maxFadeDistanceEnd = 4.0f, maxFadeDistanceStart = 3.5f;

    void Start()
    {
        Body.bodies = new List<GameObject>();
        Body.starSprite = testBodySprite;
        Body.blackHoleSprite = shadowSprite;
        Body.pixelSprite = raySprite;

      

        colorManagerSetter = gameObject.AddComponent<ColorManagerSetter>(
            //mainColor,      //0.839f, 0.278f, 0, 1
            //secondaryColor, //0, 0.223f, 0.580f, 1
            /*thirdColor*/);    //0.502f, 0.502f, 0.502f, 1

        // Autoload the online version of the database
        StartCoroutine(ImportDatabase());
    }

    private IEnumerator ImportDatabase()
    {
        WWW www = new WWW(DatabaseUrl);
        yield return www;
        LoadBodies(www.text);
        Logger.Info("Imported default star database");
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
        Body.DestroyAllBodies();
        Body.bodies.Clear();

        BodyList bl = JSONLoader.LoadStars(json);
        DataBody.LoadBodiesInGame(bl);

        GameObject tempParentGo = GameObject.Find("Bodies");
        foreach (GameObject go in Body.bodies)
        {
            go.transform.SetParent(tempParentGo.transform);
        }
    }

    public void ToggleSOIDisplay()
    {
        DisplaySOI.ShowSOI = !DisplaySOI.ShowSOI;
        Logger.Info("Toggled SOI Display. New state: " + DisplaySOI.ShowSOI);
    }

    public void ToggleLogDisplay()
    {
        Logger.Instance.gameObject.SetActive(!Logger.Instance.gameObject.activeSelf);
        Logger.Info("Toggled Log Display. New state: " + Logger.Instance.gameObject.activeSelf);
    }

    public static void VoidTemporaryGameObject()
    {
        foreach(Transform c in GameObject.Find("Temporary").transform)
        {
            Destroy(c.gameObject);
        }
    }
}
