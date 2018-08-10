using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Body
{
    public string pack, author, bodyName, bodyClass;
    public float soi;
    public Vector3 position;

    static public List<GameObject> bodies { get; set; }

    public static List<GameObject> LoadBodiesInGame(BodyList bodylist, Sprite testBodySprite)
    {
        List<GameObject> gos = new List<GameObject>();

        foreach(Body b in bodylist.bodies)
        {
            GameObject go = new GameObject(b.bodyName);
            gos.Add(go);

            //go.transform.position = b.position;

            //Puts everything on the place / rotates
            go.transform.position = new Vector3(b.position.x, b.position.z, b.position.y);

            go.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = testBodySprite;
        }

        bodies = gos;
        return gos;
    }

}
