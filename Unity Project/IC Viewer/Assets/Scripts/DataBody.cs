using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataBody
{
    public string pack, author, bodyName, bodyClass;
    public float soi;
    public Vector3 position;

    public static void LoadBodiesInGame(BodyList bodylist)
    {
        foreach (DataBody db in bodylist.bodies)
        {
            GameObject g = new GameObject(db.bodyName);
            Body b = g.AddComponent<Body>();
            b.pack = db.pack;
            b.author = db.author;
            b.bodyName = db.bodyName;
            b.bodyClass = db.bodyClass;
            b.soi = db.soi;
            b.position = db.position;

            //GameBody gb = g.AddComponent<GameBody>();
            //b.gameBody = gb;

            g.transform.position = new Vector3(b.position.x, b.position.z, b.position.y);
            g.transform.localScale = Vector3.one * 0.2f;
            DisplaySOI soi = g.AddComponent<DisplaySOI>();
            soi.SphereOfInfluence = db.soi;

            SpriteRenderer sr = g.AddComponent<SpriteRenderer>();
            b.spriteRenderer = sr;
        }
    }
}


