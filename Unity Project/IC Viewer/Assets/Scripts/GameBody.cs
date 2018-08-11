using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBody : MonoBehaviour
{
    public GameObject shadow, ray;

    public GameObject body;

    private Text nameText;

    private void Awake()
    {
        GameObject textGO = new GameObject(gameObject.name + " Name Text");
        textGO.transform.parent = GameObject.Find("World Canvas").transform;

        nameText = textGO.AddComponent<Text>();
        nameText.text = "   " + gameObject.name;

        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        nameText.font = ArialFont;
        nameText.material = ArialFont.material;       
        nameText.color = ColorManager.thirdColor; //new Color(0.847f, 0.847f, 0.847f, 1);
        nameText.resizeTextForBestFit = true;

        
        nameText.rectTransform.sizeDelta = new Vector2(100, 15);
        nameText.rectTransform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        nameText.rectTransform.pivot = new Vector2(0, 0.5f);
    }


    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;

        ray.transform.eulerAngles = new Vector3(0, Camera.main.transform.rotation.eulerAngles.y, 0);

        nameText.rectTransform.anchoredPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
        nameText.gameObject.transform.position = new Vector3(nameText.gameObject.transform.position.x, nameText.gameObject.transform.position.y, gameObject.transform.position.z);
        nameText.rectTransform.eulerAngles = new Vector3(CameraController.angle.x, CameraController.angle.y, 0);

        shadow.transform.position = new Vector3(transform.position.x, Camera.main.GetComponent<CameraController>().planeLevel, transform.position.z);
        ray.transform.position = new Vector3(gameObject.transform.position.x, (shadow.transform.position.y + gameObject.transform.position.y) / 2f, gameObject.transform.position.z);
        ray.transform.localScale = new Vector3(3f, (gameObject.transform.position.y - shadow.transform.position.y) * 100f, 0);
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
