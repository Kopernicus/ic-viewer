using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager
{
    /// <summary>
    /// The main color used in the program
    /// </summary>
    public static Color mainColor = new Color(0.839f, 0.278f, 0, 1);

    /// <summary>
    /// The secondary color used in the program
    /// </summary>
    public static Color secondaryColor = new Color(0, 0.223f, 0.580f, 1);

    /// <summary>
    /// The third color used in the program
    /// </summary>
    public static Color thirdColor = new Color(0.502f, 0.502f, 0.502f, 1);
}

/// <summary>
/// The class used to set program colors via the editor / any MonoBehaviour class
/// </summary>
public class ColorManagerSetter : MonoBehaviour
{
    public bool update = false;

    /// <summary>
    /// The main color used in the program
    /// </summary>
    public Color MainColor { get; set; }

    /// <summary>
    /// The secondary color used in the program
    /// </summary>
    public Color SecondaryColor { get; set; }

    /// <summary>
    /// The third color used in the program
    /// </summary>
    public Color ThirdColor { get; set; }

    /*public ColorManagerSetter(Color main)
    {
        MainColor = main;
    }

    public ColorManagerSetter(Color main, Color secondary)
    {
        MainColor = main;
        SecondaryColor = secondary;
    }

    public ColorManagerSetter(Color main, Color secondary, Color third)
    {
        MainColor = main;
        SecondaryColor = secondary;
        ThirdColor = third;
    }*/

    private void Start()
    {
        SetColors();
    }

    private void Update()
    {
        if (update)
        {
            SetColors();
        }
    }

    private void SetColors()
    {
        //if (MainColor != null)
        //{
            ColorManager.mainColor = MainColor;
        //}

        //if (SecondaryColor != null)
        //{
            ColorManager.secondaryColor = SecondaryColor;
        //}

        //if (ThirdColor != null)
        //{
            ColorManager.thirdColor = ThirdColor;
        //}
    }
}
