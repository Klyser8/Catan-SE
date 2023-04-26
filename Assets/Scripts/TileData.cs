using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    [SerializeField] private TileType tileType;
    private NumberData _numberData;
    
    public void Initialize(NumberData numberData)
    {
        _numberData = numberData;
    }

    public int GetNumber()
    {
        return _numberData.GetNumber();
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
