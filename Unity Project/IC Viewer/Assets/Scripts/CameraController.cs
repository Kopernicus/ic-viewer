using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
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
    }

    private void Update()
    {
        #region Scrolling
        float scrl = Input.GetAxis("Mouse ScrollWheel");
        planeLevel += scrl * scrollSensivity * Time.deltaTime;

        centerPoint = new Vector3(centerPoint.x, planeLevel, centerPoint.z);
        c.transform.position = new Vector3(transform.position.x, transform.position.y + scrl * scrollSensivity * Time.deltaTime, transform.position.z);
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
