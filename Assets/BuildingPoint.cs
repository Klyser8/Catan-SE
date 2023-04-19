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
    public bool playEffect;

    private List<GameObject> _adjacentTiles = new();
    
    // Start is called before the first frame update
    void Start()
    {

        PlayParticles();
        playEffect = true;

    }

    // Update is called once per frame
    void Update()
    {
       hasBuilding = Physics.CheckSphere(buildingCheck.position, buildingCheckDistance, buildingMask);
       
       if(playEffect) {
          if(hasBuilding) {
              playEffect = false;
              StopParticles(); 
          } 
       }
        
    }
    
    public List<GameObject> GetAdjacentTiles() {
        return _adjacentTiles;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawSphere(buildingCheck.position, buildingCheckDistance);
    }

    void PlayParticles() {
        _markerEffect.Play();
    }

    void StopParticles() {
        _markerEffect.Stop();
    }
    
    
}
