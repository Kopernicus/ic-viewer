using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBody : MonoBehaviour
{
    public GameObject shadow, ray;

    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;

        ray.transform.eulerAngles = new Vector3(0, Camera.main.transform.rotation.y * 360f, 0);
        //ray.transform.position = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y - shadow.transform.position.y) / 2f, gameObject.transform.position.z);
        //ray.transform.localScale = new Vector3(3f, (gameObject.transform.position.y - shadow.transform.position.y) * 100f, 0);

        shadow.transform.position = new Vector3(transform.position.x, Camera.main.GetComponent<CameraController>().planeLevel, transform.position.z);
    }

    public static void DestroyAllBodies()
    {
        if (Body.bodies != null)
        {
            List<GameObject> gos = Body.bodies;

            foreach (GameObject g in gos)
            {
                Destroy(g.GetComponent<GameBody>().shadow);
                Destroy(g.GetComponent<GameBody>().ray);
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
                Destroy(g.GetComponent<GameBody>().shadow);
                Destroy(g.GetComponent<GameBody>().ray);
                Destroy(g);
            }
        }
    }

    
}
