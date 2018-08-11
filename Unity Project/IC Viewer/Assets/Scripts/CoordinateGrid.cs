using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateGrid : MonoBehaviour
{
    public static GameObject CreateLine(Vector3 start, Vector3 end, Color color)
    {
        Sprite s = Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 0.05f, 0.05f), new Vector2(0.025f, 0.025f));

        GameObject g = new GameObject("Line");
        g.transform.SetParent(GameObject.Find("Temporary").transform);
        g.SetActive(false);

        SpriteRenderer sr = g.AddComponent<SpriteRenderer>();
        sr.sprite = s;
        sr.color = color;

        return g;
    }
}
