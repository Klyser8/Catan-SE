using UnityEngine;

/// <summary>
/// The `NumberData` class represents the number data associated with a tile on the game board.
/// It holds the integer represented by the number token, to be used by the tile.
/// </summary>
public class NumberData : MonoBehaviour
{
    [SerializeField] private int number;
    
    /// <summary>
    /// Retrieves the integer associated with the tile.
    /// </summary>
    /// <returns>The number value of the tile.</returns>
    public int GetNumber()
    {
        return number;
    }
    
}