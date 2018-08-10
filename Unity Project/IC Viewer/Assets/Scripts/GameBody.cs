using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBody : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    public static void DestroyAllBodies()
    {
        if (Body.bodies != null)
        {
            List<GameObject> gos = Body.bodies;

            foreach (GameObject g in gos)
            {
                Destroy(g);
            }
        }
    }

    public static void DestroyAllBodies(List<GameObject> GameObjectBodies)
    {
        if(GameObjectBodies != null)
        {
            foreach(GameObject g in GameObjectBodies)
            {
                Destroy(g);
            }
        }
    }
}
