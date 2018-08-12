using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using sc = SpectralClasses;

[System.Serializable]
public class DataBody
{
    public string pack, author, bodyName, bodyClass;
    public float soi;
    public Vector3 position;

    static public List<GameObject> bodies { get; set; }

    public static List<GameObject> LoadBodiesInGame(BodyList bodylist, Sprite testBodySprite, Sprite shadowSprite, Sprite raySprite)
    {
        List<GameObject> gos = new List<GameObject>();

        Body.starSprite = testBodySprite;
        Body.blackHoleSprite = shadowSprite;

        foreach (DataBody b in bodylist.bodies)
        {
            GameObject go = new GameObject(b.bodyName);
            gos.Add(go);
            GameBody gb = go.AddComponent<GameBody>();

            //go.transform.position = b.position;

            //Puts everything on the plane / rotates
            go.transform.position = new Vector3(b.position.x, b.position.z, b.position.y);

            go.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            go.AddComponent<DisplaySOI>().SphereOfInfluence = b.soi;

            

            SpriteRenderer sr = go.AddComponent<SpriteRenderer>();

            Sprite s;
            Color c;

            Body.ParseSpectralClass(b, out s, out c);
            //sr.sprite = testBodySprite; //srt.sprite;
            //sr.color = Color.white; //srt.color;

            sr.sprite = s;
            sr.color = c;

            #region Plane Shadow
            GameObject ps = new GameObject(b.bodyName + " Shadow");
            ps.transform.SetParent(GameObject.Find("Plane Shadows").transform);

            SpriteRenderer srps = ps.AddComponent<SpriteRenderer>();
            srps.sprite = shadowSprite;
            srps.color = ColorManager.secondaryColor; //new Color(1f, 0.5f, 0f, 1f);

            ps.transform.position = new Vector3(go.transform.position.x, Camera.main.GetComponent<CameraController>().planeLevel, go.transform.position.z);
            ps.transform.eulerAngles = new Vector3(90, 0, 0);

            gb.shadow = ps;
            #endregion

            #region Plane Rays
            GameObject pr = new GameObject(b.bodyName + " Ray");
            pr.transform.SetParent(GameObject.Find("Plane Rays").transform);

            SpriteRenderer srpr = pr.AddComponent<SpriteRenderer>();
            srpr.sprite = raySprite;
            srpr.color = ColorManager.secondaryColor; //new Color(1f, 0.5f, 0f, 1f);

            pr.transform.position = new Vector3(go.transform.position.x, (go.transform.position.y - ps.transform.position.y) / 2f, go.transform.position.z);
            gb.ray = pr;
            pr.transform.localScale = new Vector3(3f, (go.transform.position.y - ps.transform.position.y) * 100f, 0);
            #endregion

        }

        bodies = gos;
        return gos;
    }
}


