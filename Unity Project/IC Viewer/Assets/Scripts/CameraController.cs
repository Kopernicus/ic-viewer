using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{

    public Sprite cursorPlaneSprite, cursor3dPositionSprite, cursor3dArrowSprite;
    public GameObject cursor, cursorPlane, cursor3d;
    public float cursorSize;

    //Please leave for the test,
    //'cause i've an Azerty keyboard so i need to change them lol
    public KeyCode
        forward = KeyCode.W,
        left = KeyCode.A,
        backward = KeyCode.S,
        right = KeyCode.D;

    public float scrollSensivity = 100.0f;
    public float mouseSensivity = 80.0f;
    public float moveSpeed = 20.0f;

    public float maxAngle = 75.0f;

    public float planeLevel = 0.0f;

    public Vector3 centerPoint;
    Vector3 truePos;

    private Camera c;

    private void Start()
    {
        c = GetComponent<Camera>();
        centerPoint = new Vector3(0, planeLevel, -3);
        c.transform.LookAt(centerPoint);

        #region Cursor
        cursor = new GameObject("Map Cursor");

        cursorPlane = new GameObject("Map Cursor Plane");
        cursor3d = new GameObject("Map Cursor 3D");

        cursorPlane.transform.SetParent(cursor.transform);
        cursor3d.transform.SetParent(cursor.transform);
        cursor3d.transform.localPosition = new Vector3(0, 0.3f, 0);

        Color cursorColor = new Color(0f, 0.5f, 1f, 1f);
        cursorPlane.transform.eulerAngles = new Vector3(90, 0, 0);
        SpriteRenderer cpsr = cursorPlane.AddComponent<SpriteRenderer>();
        cpsr.sprite = cursorPlaneSprite;
        cpsr.color = cursorColor;

        SpriteRenderer c3sr = cursor3d.AddComponent<SpriteRenderer>();
        c3sr.sprite = cursor3dPositionSprite;
        c3sr.color = cursorColor;


        #endregion
    }

    private void Update()
    {
        #region Scrolling
        //Zooming
        float scrl = Input.GetAxis("Mouse ScrollWheel");
        planeLevel += scrl * scrollSensivity * Time.deltaTime;

        centerPoint = new Vector3(centerPoint.x, planeLevel, centerPoint.z);
        c.transform.position = new Vector3(transform.position.x, transform.position.y + scrl * scrollSensivity * Time.deltaTime, transform.position.z);

        if(scrl != 0)
        {
            cursor3d.GetComponent<SpriteRenderer>().sprite = cursor3dArrowSprite;
        }
        else
        {
            cursor3d.GetComponent<SpriteRenderer>().sprite = cursor3dPositionSprite;
        }
        #endregion

        #region Rotation
        if (Input.GetMouseButton(1))
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");

            transform.RotateAround(centerPoint, Vector3.up, mx * mouseSensivity * Time.deltaTime);
            transform.RotateAround(centerPoint, transform.right, my * mouseSensivity * Time.deltaTime);
        }      
        #endregion

        #region Moving
        if(Input.GetKey(forward))
        {
            centerPoint = new Vector3(centerPoint.x + (c.transform.forward.x * moveSpeed * Time.deltaTime), centerPoint.y, centerPoint.z + (c.transform.forward.z * moveSpeed * Time.deltaTime));
            transform.position = new Vector3(transform.position.x + (transform.forward.x * moveSpeed * Time.deltaTime), transform.position.y, transform.position.z + (transform.forward.z * moveSpeed * Time.deltaTime));
        }
        if(Input.GetKey(backward))
        {
            centerPoint = new Vector3(centerPoint.x - (c.transform.forward.x * moveSpeed * Time.deltaTime), centerPoint.y, centerPoint.z - (c.transform.forward.z * moveSpeed * Time.deltaTime));
            transform.position = new Vector3(transform.position.x - (transform.forward.x * moveSpeed * Time.deltaTime), transform.position.y, transform.position.z - (transform.forward.z * moveSpeed * Time.deltaTime));
        }
        if(Input.GetKey(left))
        {
            centerPoint = new Vector3(centerPoint.x + (-c.transform.right.x * moveSpeed * Time.deltaTime), centerPoint.y, centerPoint.z + (-c.transform.right.z * moveSpeed * Time.deltaTime));
            transform.position = new Vector3(transform.position.x + (-transform.right.x * moveSpeed * Time.deltaTime), transform.position.y, transform.position.z + (-transform.right.z * moveSpeed * Time.deltaTime));
        }
        if (Input.GetKey(right))
        {
            centerPoint = new Vector3(centerPoint.x + (c.transform.right.x * moveSpeed * Time.deltaTime), centerPoint.y, centerPoint.z + (c.transform.right.z * moveSpeed * Time.deltaTime));
            transform.position = new Vector3(transform.position.x + (transform.right.x * moveSpeed * Time.deltaTime), transform.position.y, transform.position.z + (transform.right.z * moveSpeed * Time.deltaTime));
        }
        #endregion

        //Debug.Log("Clamped: " + ClampAngle(-maxAngle, maxAngle, transform.rotation.x * 360f));
        //Debug.Log(transform.rotation.x * 360f);

        cursor.transform.localScale = new Vector3(cursorSize, cursorSize, cursorSize);

        cursor.transform.eulerAngles = new Vector3(0, c.transform.rotation.y * 360f, 0);
        cursor.transform.position = centerPoint;
    }

    private float ClampAngle(float minAngle, float maxAngle, float angle)
    {
        float a = 0.0f;

        //Minimum
        if(angle < minAngle)
        {
            a = minAngle;
        }
        
        //Maximum
        if(angle > maxAngle)
        {
            a = maxAngle;
        }

        //If the angle is good
        if(angle >= minAngle && angle <= maxAngle)
        {
            a = angle;
        }

        return a;
    }
}
