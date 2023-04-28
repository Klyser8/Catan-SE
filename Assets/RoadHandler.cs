using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RoadHandler class handles the logic for creating roads in the game.
/// </summary>
public class RoadHandler : MonoBehaviour
{
    public GameObject road;

    /// <summary>
    /// Instantiates a new road at the specified position and rotation.
    /// </summary>
    /// <param name="pos">The position to create the road at.</param>
    /// <param name="rot">The initial rotation for the road.</param>
    public void BuildRoad(Vector3 pos, Quaternion rot)
    {
        Quaternion additionalRotation = Quaternion.Euler(Vector3.up * 90);
        Quaternion finalRotation = rot * additionalRotation;
        GameObject newRoad = Instantiate(road, pos, finalRotation);
    }
}

