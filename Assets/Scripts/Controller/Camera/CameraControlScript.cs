using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlScript : MonoBehaviour
{
    public float scrollSpeed = 10;
    public float lowerBoundFieldOfView = 50;
    public float upperBoundFieldOfView = 100;
    private Camera zoomCamera;
    private Transform player;

    // Panning
    private float rotationSpeed = 500.0f;
    private Vector3 mouseWorldPosStart;
    private float lastClickTime;


    private void Start()
    {
        zoomCamera = Camera.main;
        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        float zoomChange = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        bool isZoomingIn = zoomChange > 0;

        // Enforce upper & lower bounds
        float finalFieldOfView = zoomCamera.fieldOfView - zoomChange;
        if (finalFieldOfView < lowerBoundFieldOfView)
        {
            zoomCamera.fieldOfView = lowerBoundFieldOfView;
        }
        else if (finalFieldOfView > upperBoundFieldOfView)
        {
            zoomCamera.fieldOfView = upperBoundFieldOfView;
        }
        else
        {
            zoomCamera.fieldOfView -= zoomChange;
        }


        if (Input.GetKey(KeyCode.Mouse2))
        {
            CamOrbit();
        }

        if (Input.GetMouseButtonDown(2))
        {
            mouseWorldPosStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(2))
        {
            Pan();
        }

        if (Input.GetMouseButtonDown(2))
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= 0.25)
                transform.LookAt(player);

            lastClickTime = Time.time;
        }
    }

    private void CamOrbit()
    {
        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            float verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.right, -verticalInput);
            transform.Rotate(Vector3.down, -horizontalInput);
        }
    }

    private void Pan()
    {
        if (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            Vector3 mouseWorldPosDiff = mouseWorldPosStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += mouseWorldPosDiff;
        }
    }

}
