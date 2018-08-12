using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public static Sprite starSprite, blackHoleSprite;

    public string pack, author, bodyName, bodyClass;
    public float soi;
    public Vector3 position;

    public static void ParseSpectralClass(DataBody b, out Sprite sprite, out Color color)
    {
        SpriteRenderer sr = new SpriteRenderer();
        color = Color.white;
        sprite = starSprite;

        if (IsSpectralClassSupported(b))
        {
            if (b.bodyClass == "M")
            {
                sprite = starSprite;
                color = new Color32(255, 163, 79, 255);
            }
            if (b.bodyClass == "K")
            {
                sprite = starSprite;
                color = new Color32(255, 213, 180, 255);
            }
            if (b.bodyClass == "G")
            {
                sprite = starSprite;
                color = new Color32(255, 237, 222, 255);
            }
            if (b.bodyClass == "F")
            {
                sprite = starSprite;
                color = new Color32(247, 245, 255, 255);
            }
            if (b.bodyClass == "A")
            {
                sprite = starSprite;
                color = new Color32(209, 222, 255, 255);
            }
            if (b.bodyClass == "B")
            {
                sprite = starSprite;
                color = new Color32(181, 205, 255, 255);
            }
            if (b.bodyClass == "O")
            {
                sprite = starSprite;
                color = new Color32(112, 157, 255, 255);
            }
            if (b.bodyClass == "X")
            {
                sprite = blackHoleSprite;
                color = new Color32(40, 40, 40, 255);
            }
            if(b.bodyClass == "Unknown")
            {
                sprite = blackHoleSprite;
                color = new Color(1, 0, 1, 1);
            }
        }

        else
        {
            sprite = blackHoleSprite;
            color = new Color(1, 0, 1, 1);

            Debug.LogWarning(b.bodyName + "'s spectral class [" + b.bodyClass + "]" +
                " is not supported byt the spectral parser !");
        }
    }

    public static bool IsSpectralClassSupported(DataBody b)
    {
        return SpectralClasses.IsDefined(typeof(SpectralClasses), b.bodyClass);
    }

}

public enum SpectralClasses
{
    M,
    K,
    G,
    F,
    A,
    B,
    O,
    X,
    Unknown
}
