using System;
using System.IO.IsolatedStorage;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

public class Logger : MonoBehaviour
{
    /// <summary>
    /// The UI element that is used to display the log
    /// </summary>
    private InputField _display;

    /// <summary>
    /// Whether to use colored text
    /// </summary>
    public Boolean UseRichText = true;
    
    /// <summary>
    /// The color that is used for debug messages
    /// </summary>
    public Color ColorDebug = Color.green;

    /// <summary>
    /// The color that is used for normal messages
    /// </summary>
    public Color ColorInfo = Color.white;

    /// <summary>
    /// The color that is used for warning messages
    /// </summary>
    public Color ColorWarning = Color.yellow;

    /// <summary>
    /// The color that is used for error messages
    /// </summary>
    public Color ColorError = Color.red;

    /// <summary>
    /// The global instance of the logging system
    /// </summary>
    private static Logger _instance;
    
    /// <summary>
    /// Grab the UI element
    /// </summary>
    void Start()
    {
        _display = GetComponent<InputField>();
        if (_instance != null)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
        
        // Say hello
        Info("Initializing ic-viewer.");
    }

    /// <summary>
    /// Logs a debug message
    /// </summary>
    public static void Debug(Object message)
    {
        UnityEngine.Debug.Log(message);
        #if UNITY_EDITOR
        String formatted = "[DBG] " + message;
        if (_instance.UseRichText)
        {
            formatted = "<color=" + ColorToHex(_instance.ColorDebug) + ">" + formatted + "</color>";
        }

        _instance._display.text += formatted + "\n";
        #endif
    }

    /// <summary>
    /// Logs an info message
    /// </summary>
    public static void Info(Object message)
    {
        UnityEngine.Debug.Log(message);
        String formatted = "[LOG] " + message;
        if (_instance.UseRichText)
        {
            formatted = "<color=" + ColorToHex(_instance.ColorInfo) + ">" + formatted + "</color>";
        }

        _instance._display.text += formatted + "\n";
    }

    /// <summary>
    /// Logs a warning message
    /// </summary>
    public static void Warning(Object message)
    {
        UnityEngine.Debug.LogWarning(message);
        String formatted = "[WRN] " + message;
        if (_instance.UseRichText)
        {
            formatted = "<b><color=" + ColorToHex(_instance.ColorWarning) + ">" + formatted + "</color></b>";
        }

        _instance._display.text += formatted + "\n";
    }

    /// <summary>
    /// Logs an error message
    /// </summary>
    public static void Error(Object message)
    {
        UnityEngine.Debug.LogError(message);
        String formatted = "[ERR] " + message;
        if (_instance.UseRichText)
        {
            formatted = "<b><color=" + ColorToHex(_instance.ColorError) + ">" + formatted + "</color></b>";
        }

        _instance._display.text += formatted + "\n";
    }

    /// <summary>
    /// Converts a Unity color into a html hex color
    /// </summary>
    private static String ColorToHex(Color32 color)
    {
        String red = BitConverter.ToString(new[] {color.r});
        String green = BitConverter.ToString(new[] {color.g});
        String blue = BitConverter.ToString(new[] {color.b});
        String alpha = BitConverter.ToString(new[] {color.a});
        return "#" + red + green + blue + alpha;
    }
}