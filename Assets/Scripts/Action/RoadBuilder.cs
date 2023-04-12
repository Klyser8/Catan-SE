using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

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

    public VisualEffect _buildHereLeft;
    public VisualEffect _buildHereRight;

    public bool playLeft = false;
    public bool playRight = false;

    public bool hasRoad = false;

    public bool hasRoadOnSide = false;

    public bool canBuild = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hasRoad = Physics.CheckSphere(checkRoad.position, checkDistance, roadMask);
        if(!hasRoad) 
        {
            //Vuildings on side
            if(Physics.CheckSphere(checkBuildingLeft.position, checkDistance, buildingMask)) {
                if(!playLeft){
                    playLeft = true;
                    PlayParticalLeft();
                    canBuild = true;
                }
            } 

            if(Physics.CheckSphere(checkBuildingRight.position, checkDistance, buildingMask) ) {
                if(!playRight){
                    playRight = true;
                    PlayParticalRight();
                    canBuild = true;
                }
            }

            //Roads on sides 
            if(Physics.CheckSphere(otherRoadLeft.position, otherRoadDistance, roadMask)) {
                hasRoadOnSide = true;
                if(!playLeft) {
                    if(!playLeft){
                        playLeft = true;
                        PlayParticalLeft();
                        canBuild = true;
                    }
                }
            }
            if(Physics.CheckSphere(otherRoadRight.position, otherRoadDistance, roadMask)) {
                hasRoadOnSide = true;
                if(!playRight) {
                    if(!playRight){
                        playRight = true;
                        PlayParticalRight();
                        canBuild = true;
                    }
                }
            }

            if(Physics.CheckSphere(otherRoadLeftTwo.position, otherRoadDistance, roadMask)) {
                hasRoadOnSide = true;
                if(!playLeft) {
                    if(!playLeft){
                        playLeft = true;
                        PlayParticalLeft();
                        canBuild = true;
                    }
                }
            }
            if(Physics.CheckSphere(otherRoadRightTwo.position, otherRoadDistance, roadMask)) {
                hasRoadOnSide = true;
                if(!playRight) {
                    if(!playRight){
                        playRight = true;
                        PlayParticalRight();
                        canBuild = true;
                    }
                }
            }
        }

       

        if(hasRoad) {
            if(playLeft) {
                playLeft = false;
                StopParticalLeft();
                canBuild = false;
            }
            if(playRight) {
                playRight = false;
                StopParticalRight();
                canBuild = false;
            }
        } 
    }

    // private void OnDrawGizmos() {
    //     Gizmos.DrawSphere(checkBuildingLeft.position, checkDistance);
    // }

    private void OnDrawGizmos() {
        Gizmos.DrawSphere(checkBuildingRight.position, checkDistance);
        Gizmos.DrawSphere(otherRoadRight.position, otherRoadDistance);
        
    }

    // private void OnDrawGizmos() {
    //     Gizmos.DrawSphere(checkRoad.position, checkDistance);
    // }

    void PlayParticalLeft() {
        Debug.Log("Play Left");
        _buildHereLeft.Play();
    }

    void StopParticalLeft() {
        Debug.Log("Stop Left");
        _buildHereLeft.Stop();
    }

    void PlayParticalRight() {
        Debug.Log("Play Right");
        _buildHereRight.Play();
    }

    void StopParticalRight() {
        Debug.Log("Play Right");
        _buildHereRight.Stop();
    }
}
