using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Sprite cursorPlaneSprite, cursor3dPositionSprite, cursor3dArrowSprite;
    public GameObject cursor, cursorPlane, cursor3d;
    public float cursorSize;

    GameObject cam;

    private void Start()
    {
        cursor = new GameObject("Map Cursor");

        cursorPlane = new GameObject("Map Cursor Plane");
        cursor3d = new GameObject("Map Cursor 3D");

        cursorPlane.transform.SetParent(cursor.transform);
        cursor3d.transform.SetParent(cursor.transform);
        cursor3d.transform.localPosition = new Vector3(0, 0.3f, 0);

        Color cursorColor;
        cursorColor = ColorManager.secondaryColor; //new Color(0f, 0.5f, 1f, 1f);
        cursorPlane.transform.eulerAngles = new Vector3(90, 0, 0);
        SpriteRenderer cpsr = cursorPlane.AddComponent<SpriteRenderer>();
        cpsr.sprite = cursorPlaneSprite;
        cpsr.color = cursorColor;

        SpriteRenderer c3sr = cursor3d.AddComponent<SpriteRenderer>();
        c3sr.sprite = cursor3dPositionSprite;
        c3sr.color = cursorColor;

        cam = Camera.main.gameObject;
    }

    private void Update()
    {
        if (Input.GetMouseButton(2))
        {
            cursor3d.GetComponent<SpriteRenderer>().sprite = cursor3dArrowSprite;
        }

        else
        {
            cursor3d.GetComponent<SpriteRenderer>().sprite = cursor3dPositionSprite;
        }

        cursor.transform.localScale = new Vector3(cursorSize, cursorSize, cursorSize);

        cursor.transform.eulerAngles = new Vector3(0, cam.transform.rotation.eulerAngles.y, 0);

        cursor.transform.position = CameraController.centerPoint;

        if (EditorManager.colorManagerSetter.update)
        {
            cursorPlane.GetComponent<SpriteRenderer>().color =
                cursor3d.GetComponent<SpriteRenderer>().color = ColorManager.secondaryColor;
        }
    }
}
