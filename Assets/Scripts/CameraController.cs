using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The center point to rotate around
    public float distance = 10.0f; // The initial distance from the target
    public float minDistance = 3.0f; // The minimum zoom distance
    public float maxDistance = 8.0f; // The maximum zoom distance
    public float zoomSpeed = 1.0f; // The speed of zooming in/out
    public float rotationSpeed = 720.0f; // The speed of rotation
    public float minYAngle = 30.0f;
    public float maxYAngle = 90.0f;

    private float _xRotation = 0.0f;
    private float _yRotation = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        _xRotation = angles.y;
        _yRotation = angles.x;
    }

    void Update()
    {
        if (target)
        {
            if (Input.GetMouseButton(2))
            {
                _xRotation += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
                _yRotation -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

                _yRotation = ClampAngle(_yRotation, minYAngle, maxYAngle);
            }

            distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            Quaternion rotation = Quaternion.Euler(_yRotation, _xRotation, 0);
            Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360.0f)
            angle += 360.0f;
        if (angle > 360.0f)
            angle -= 360.0f;
        return Mathf.Clamp(angle, min, max);
    }
}
