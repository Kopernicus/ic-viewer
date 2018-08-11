using System;
using System.Collections.Generic;
using SFB;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    public Sprite testBodySprite, shadowSprite, raySprite;

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
}
