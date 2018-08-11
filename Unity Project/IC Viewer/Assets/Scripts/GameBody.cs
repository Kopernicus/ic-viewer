using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBody : MonoBehaviour
{
    public GameObject shadow, ray;

    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        //Debug.DrawLine(transform.position, shadow.transform.position, new Color(1f, 0.5f, 0f, 1f));
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
