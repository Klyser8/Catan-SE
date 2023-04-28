using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

/// <summary>
/// RoadBuilder class handles the logic for checking if a road can be built at a specific location,
/// manages particle effects, and checks for adjacent roads or buildings.
/// </summary>
public class RoadBuilder : MonoBehaviour
{
    public Transform checkBuildingLeft;
    public Transform checkBuildingRight;
    public Transform checkRoad;
    public Transform otherRoadLeft;
    public Transform otherRoadLeftTwo;
    public Transform otherRoadRight;
    public Transform otherRoadRightTwo;

    public float checkDistance = 0.1f;
    public float otherRoadDistance = 0.1f;
    public LayerMask buildingMask;
    public LayerMask roadMask;

    public VisualEffect buildHereLeft;
    public VisualEffect buildHereRight;

    public bool playLeft = false;
    public bool playRight = false;

    public bool hasRoad = false;

    public bool hasRoadOnSide = false;

    public bool canBuild = false;

    /// <summary>
    /// Initiate Check Sphere, checks for roads. If there is no road plays Visual Effect
    /// </summary>
    void Update()
    {
        hasRoad = Physics.CheckSphere(checkRoad.position, checkDistance, roadMask);

        if (!hasRoad)
        {
            UpdatePlayState(ref playLeft,
            checkBuildingLeft, otherRoadLeft, otherRoadLeftTwo, buildHereLeft);
            UpdatePlayState(ref playRight,
            checkBuildingRight, otherRoadRight, otherRoadRightTwo, buildHereRight);
            canBuild = playLeft || playRight;
        }
        else
        {
            SetPlayState(false, ref playLeft, buildHereLeft);
            SetPlayState(false, ref playRight, buildHereRight);
            canBuild = false;
        }
    }

    /// <summary>
    /// Updates the play state based on the given parameters.
    /// </summary>
    private void UpdatePlayState(ref bool playState, Transform checkBuilding,
        Transform otherRoad1, Transform otherRoad2, VisualEffect buildHere)
    {
        if (!playState)
        {
            if (CanBuildAt(checkBuilding.position, checkDistance, buildingMask)
            || CanBuildAt(otherRoad1.position, otherRoadDistance, roadMask)
            || CanBuildAt(otherRoad2.position, otherRoadDistance, roadMask))
            {
                SetPlayState(true, ref playState, buildHere);
            }
        }
    }

    /// <summary>
    /// Sets the play state for the given VisualEffect and updates the reference boolean.
    /// </summary>
    private void SetPlayState(bool state, ref bool playState, VisualEffect buildHere)
    {
        playState = state;
        if (state)
        {
            buildHere.Play();
        }
        else
        {
            buildHere.Stop();
        }
    }

    /// <summary>
    /// Determines if the road can be built at the given position with the specified distance and layer mask.
    /// </summary>
    private bool CanBuildAt(Vector3 position, float distance, LayerMask layerMask)
    {
        return Physics.CheckSphere(position, distance, layerMask);
    }

    /// <summary>
    /// Draws spheres at the building and road check positions in the editor.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(checkBuildingRight.position, checkDistance);
        Gizmos.DrawSphere(otherRoadRight.position, otherRoadDistance);
    }
}
