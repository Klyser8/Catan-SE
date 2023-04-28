using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

/// <summary>
/// BuildingPoint class handles the logic for checking if a building is present at a specific point
/// and manages particle effects accordingly.
/// </summary>
public class BuildingPoint : MonoBehaviour
{
    public Transform buildingCheck;
    public float buildingCheckDistance = 0.01f;
    public LayerMask buildingMask;
    [SerializeField] public bool hasBuilding = false;

    public VisualEffect _markerEffect;
    public bool playEffect;

    private List<GameObject> _adjacentTiles = new();

    /// <summary>
    /// Initiate Visual Effect and sets boolean playEffect to true
    /// </summary>
    void Start()
    {
        PlayParticles();
        playEffect = true;
    }

    /// <summary>
    /// Checking for buildings around the point. If there is one, Stops Visua; Effect 
    /// </summary>
    void Update()
    {
        hasBuilding = Physics.CheckSphere(buildingCheck.position, buildingCheckDistance, buildingMask);

        if(playEffect)
        {
            if(hasBuilding)
            {
                playEffect = false;
                StopParticles();
            }
        }
    }

    /// <summary>
    /// Returns the list of adjacent tiles.
    /// </summary>
    /// <returns>List of adjacent GameObjects</returns>
    public List<GameObject> GetAdjacentTiles()
    {
        return _adjacentTiles;
    }

    /// <summary>
    /// Draws a sphere at the building check position in the editor.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(buildingCheck.position, buildingCheckDistance);
    }

    /// <summary>
    /// Plays the particle effect.
    /// </summary>
    void PlayParticles()
    {
        _markerEffect.Play();
    }

    /// <summary>
    /// Stops the particle effect.
    /// </summary>
    void StopParticles()
    {
        _markerEffect.Stop();
    }
}

