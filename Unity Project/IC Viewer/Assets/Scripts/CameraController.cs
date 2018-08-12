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

    public static Vector3 centerPoint;
    Vector3 truePos;

    private Camera c;

    public static Vector3 angle;

    private void Start()
    {
        c = GetComponent<Camera>();
        centerPoint = new Vector3(0, planeLevel, -3);
        c.transform.LookAt(centerPoint);
    }

    private void FixedUpdate()
    {
        angle = c.transform.rotation.eulerAngles;

        #region Scrolling
        //Zooming
        float scrl = Input.GetAxis("Mouse ScrollWheel");

        //c.transform.position += c.transform.forward * scrollSensivity * Time.deltaTime * scrl;

        /*planeLevel += scrl * scrollSensivity * Time.deltaTime;

        centerPoint = new Vector3(centerPoint.x, planeLevel, centerPoint.z);
        c.transform.position = new Vector3(transform.position.x, transform.position.y + scrl * scrollSensivity * Time.deltaTime, transform.position.z);
        */

        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(2))
        {
            float yPos = my * mouseSensivity * Time.deltaTime;
            c.transform.position = new Vector3(c.transform.position.x, c.transform.position.y + yPos, c.transform.position.z);
            planeLevel += yPos;
        }
        #endregion

        #region Rotation
        if (Input.GetMouseButton(1))
        {
            //Sides
            transform.RotateAround(centerPoint, Vector3.up, mx * mouseSensivity * Time.deltaTime);

            //Height
            /*if (angle.x > -maxAngle + 5 || angle.x < maxAngle - 5)
            {*/
                transform.RotateAround(centerPoint, transform.right, my * mouseSensivity * Time.deltaTime);
            //}
            
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

        #region Max Rotation
        
        #endregion

        centerPoint.y = planeLevel;
        
        //gameObject.transform.Translate(-gameObject.transform.forward * scrl * Time.deltaTime * scrollSensivity);

		float ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");           //This little peece of code is written by JelleWho https://github.com/jellewie
		if (ScrollWheelChange != 0){                                            //If the scrollwheel has changed
			float R = ScrollWheelChange * 15;                                   //The radius from current camera
			float PosX = Camera.main.transform.eulerAngles.x + 90;              //Get up and down
			float PosY = -1 * (Camera.main.transform.eulerAngles.y - 90);       //Get left to right
			PosX = PosX / 180 * Mathf.PI;                                       //Convert from degrees to radians
			PosY = PosY / 180 * Mathf.PI;                                       //^
			float X = R * Mathf.Sin(PosX) * Mathf.Cos(PosY);                    //Calculate new coords
			float Z = R * Mathf.Sin(PosX) * Mathf.Sin(PosY);                    //^
			float Y = R * Mathf.Cos(PosX);                                      //^
			float CamX = Camera.main.transform.position.x;                      //Get current camera postition for the offset
			float CamY = Camera.main.transform.position.y;                      //^
			float CamZ = Camera.main.transform.position.z;                      //^
			Camera.main.transform.position = new Vector3(CamX + X, CamY + Y, CamZ + Z);//Move the main camera
		}
    }
}
