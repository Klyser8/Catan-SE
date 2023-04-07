using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BuildingPoint : MonoBehaviour
{
    // public GameObject settelment;
    // public GameObject city;

    public Transform buildingCheck;
    public float buildingCheckDistance = 0.01f;
    public LayerMask buildingMask;
    private bool hasBuilding = false;

    public VisualEffect _markerEffect;

    
    
    // Start is called before the first frame update
    void Start()
    {
        PlayPartical();
    }

    // Update is called once per frame
    void Update()
    {
       hasBuilding = Physics.CheckSphere(buildingCheck.position, buildingCheckDistance, buildingMask);
       
       if(hasBuilding) {
            StopPartical(); 
        } 
        
    }

    private void OnDrawGizmos() {
        Gizmos.DrawSphere(buildingCheck.position, buildingCheckDistance);
    }

    void PlayPartical() {
        _markerEffect.Play();
    }

    void StopPartical() {
        _markerEffect.Stop();
    }
    
    
}
