using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    
    private GameObject _number;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void SetNumber(GameObject number)
    {
        _number = number;
    }
    
    public GameObject GetNumber()
    {
        return _number;
    }
    
}
