using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BuildingPoint : MonoBehaviour
{
    public Transform buildingCheck;
    public float buildingCheckDistance = 0.01f;
    public LayerMask buildingMask;
    [SerializeField] public bool hasBuilding = false;

    public VisualEffect _markerEffect;

    
    
    // Start is called before the first frame update
    void Start()
    {
        PlayParticles();
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

    void PlayParticles() {
        _markerEffect.Play();
    }

    void StopPartical() {
        _markerEffect.Stop();
    }
    
    
}
