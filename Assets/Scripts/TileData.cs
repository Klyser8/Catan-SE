using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The `TileData` class represents the data associated with a tile on the game board.
/// It holds information about the tile type and the number data associated with it.
/// </summary>
public class TileData : MonoBehaviour
{
    [SerializeField] private TileType tileType;
    private NumberData _numberData;
    
    /// <summary>
    /// Initializes the tile data with the provided number data.
    /// </summary>
    /// <param name="numberData">The number data associated with the tile.</param>
    public void Initialize(NumberData numberData)
    {
        _numberData = numberData;
    }

    /// <summary>
    /// Retrieves the number associated with the tile. Used for determining resource production.
    /// </summary>
    /// <returns>The number value of the tile.</returns>
    public int GetNumber()
    {
        return _numberData.GetNumber();
    }
    
    /// <summary>
    /// Retrieves the type of the tile. See `TileType` for possible values.
    /// </summary>
    /// <returns>The type of the tile.</returns>
    public TileType GetTileType()
    {
        return tileType;
    }
    
}

/// <summary>
/// The `TileType` enum represents the different types of tiles that can be present on the game board.
/// Used for determining resource production.
/// </summary>
public enum TileType
{
    Desert,
    Forest,
    Field,
    Hay,
    Ore,
    Clay
}
