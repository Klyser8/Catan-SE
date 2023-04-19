using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    
    private GameObject _number;
    public TileType tileType;
    
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
    
    public TileType GetTileType()
    {
        return tileType;
    }
    
}

public enum TileType
{
    Desert,
    Forest,
    Field,
    Hay,
    Ore,
    Clay
}
