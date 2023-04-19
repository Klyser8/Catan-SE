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

    public VisualEffect buildHereLeft;
    public VisualEffect buildHereRight;

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
                    PlayParticleLeft();
                    canBuild = true;
                }
            } 

            if(Physics.CheckSphere(checkBuildingRight.position, checkDistance, buildingMask) ) {
                if(!playRight){
                    playRight = true;
                    PlayParticleRight();
                    canBuild = true;
                }
            }

            //Roads on sides 
            if(Physics.CheckSphere(otherRoadLeft.position, otherRoadDistance, roadMask)) {
                hasRoadOnSide = true;
                if(!playLeft) {
                    if(!playLeft){
                        playLeft = true;
                        PlayParticleLeft();
                        canBuild = true;
                    }
                }
            }
            if(Physics.CheckSphere(otherRoadRight.position, otherRoadDistance, roadMask)) {
                hasRoadOnSide = true;
                if(!playRight) {
                    if(!playRight){
                        playRight = true;
                        PlayParticleRight();
                        canBuild = true;
                    }
                }
            }

            if(Physics.CheckSphere(otherRoadLeftTwo.position, otherRoadDistance, roadMask)) {
                hasRoadOnSide = true;
                if(!playLeft) {
                    if(!playLeft){
                        playLeft = true;
                        PlayParticleLeft();
                        canBuild = true;
                    }
                }
            }
            if(Physics.CheckSphere(otherRoadRightTwo.position, otherRoadDistance, roadMask)) {
                hasRoadOnSide = true;
                if(!playRight) {
                    if(!playRight){
                        playRight = true;
                        PlayParticleRight();
                        canBuild = true;
                    }
                }
            }
        }

       

        if(hasRoad) {
            if(playLeft) {
                playLeft = false;
                StopParticleLeft();
                canBuild = false;
            }
            if(playRight) {
                playRight = false;
                StopParticleRight();
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

    void PlayParticleLeft() {
        Debug.Log("Play Left");
        buildHereLeft.Play();
    }

    void StopParticleLeft() {
        Debug.Log("Stop Left");
        buildHereLeft.Stop();
    }

    void PlayParticleRight() {
        Debug.Log("Play Right");
        buildHereRight.Play();
    }

    void StopParticleRight() {
        Debug.Log("Play Right");
        buildHereRight.Stop();
    }
}
