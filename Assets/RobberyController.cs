using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberyController : MonoBehaviour
{
    public GameObject robbery;
    public Vector3 targetCoordinates;
    public Vector3 lastCoordinates;
    public float rotationSpeed = 2.0f;
    public float movementSpeed = 5.0f;

    public bool canMove = false;

    // Update is called once per frame
    void Update()
    {
        if(canMove && targetCoordinates != lastCoordinates) {
            if (robbery != null)
            {
                RotateGameObjectToCoordinates(robbery.transform);
                MoveGameObjectToCoordinates(robbery.transform);
                canMove = false;
                lastCoordinates = targetCoordinates;
            }
        }
        
    }

    public void ButtonMoveRobbery() {
        canMove = true;
    }

    public void SpawnRobbery(Vector3 position)
    {
        var newRobbery = Instantiate(robbery);
        newRobbery.transform.position = position;
        robbery = newRobbery;
        lastCoordinates = position;
        return;
    }

    public void ReceiveCoordinates (Vector3 position) {
        targetCoordinates = position;
    }


    void RotateGameObjectToCoordinates(Transform robberyTransform)
    {
        // Calculate the direction vector to the target coordinates
        Vector3 direction = targetCoordinates - robberyTransform.position;

        // Create a rotation that looks along the direction vector
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate the GameObject towards the target rotation
        robberyTransform.rotation = Quaternion.Slerp(robberyTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    void MoveGameObjectToCoordinates(Transform robberyTransform)
    {
        // Calculate the direction vector to the target coordinates
        Vector3 direction = targetCoordinates - robberyTransform.position;

        // Normalize the direction vector
        direction.Normalize();

        // Move the GameObject towards the target coordinates
        robberyTransform.position += direction * movementSpeed * Time.deltaTime;
    }
}

