using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class BodyList
{
    public List<Body> bodies;
}

public class JSONLoader : MonoBehaviour
{
    /*private void Start()
    {
        foreach(Body b in LoadStarsInFile(
            @"C:\Users\Arthur\Desktop\test\icgalaxy.json").bodies)
        {
            Debug.Log(b.bodyName);
        }
    }*/

    public static BodyList bodyList { get; set; }

    public static void DeleteAllBodies()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Body"))
        {
            Destroy(g);
        }
    }

    public static BodyList LoadStars(string json)
    {
        return bodyList = JsonUtility.FromJson<BodyList>(json);
    }
}
