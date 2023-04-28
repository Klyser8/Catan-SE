using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The `BoardGenerator` class generates the game board with tiles and number tokens.
/// It populates the board with different types of tiles and assigns random numbers to them.
/// The class also handles the assignment of adjacent tiles to building points on the board.
/// </summary>
public class BoardGenerator : MonoBehaviour
{

    [SerializeField] private List<TilePrefabData> tilePrefabs;
    [SerializeField] private List<NumberPrefabData> numberPrefabs;
    [SerializeField] private Transform buildingPointsHolder;
    [SerializeField] private GameObject desertTile;
    
    private ArrayList _tilePositions = new()
    {
        //Middle row
        new Vector3(0f, 0f, 0f),
        new Vector3(0.866f, 0f, 0f),
        new Vector3(1.732f, 0f, 0f),
        new Vector3(-0.866f, 0f, 0f),
        new Vector3(-1.732f, 0f, 0f),
        //Left Row
        new Vector3(-1.299f, 0f, 0.751f),
        new Vector3(-0.433f, 0f, 0.751f),
        new Vector3(0.433f, 0f, 0.751f),
        new Vector3(1.299f, 0f, 0.751f),
        //Right Row
        new Vector3(-1.299f, 0f, -0.751f),
        new Vector3(-0.433f, 0f, -0.751f),
        new Vector3(0.433f, 0f, -0.751f),
        new Vector3(1.299f, 0f, -0.751f),
        //Left-Left Row
        new Vector3(-0.866f, 0f, 1.499f),
        new Vector3(0f, 0f, 1.499f),
        new Vector3(0.866f, 0f, 1.499f),
        //Right-Right Row
        new Vector3(-0.866f, 0f, -1.5f),
        new Vector3(-0f, 0f, -1.5f),
        new Vector3(0.866f, 0f, -1.5f),
    };

    private Dictionary<Vector3, GameObject> _tileDictionary = new();

    void Start()
    {
        PopulateBoard();
        AssignAdjacentTilesToBuildingPoints();
    }

    /// <summary>
    /// Populates the game board with tiles and their corresponding number tokens.
    /// The method creates each type of tile based on the specified quantities and
    /// assigns random numbers to the tiles (excluding the desert tile).
    /// The created tiles and their positions are stored in the tile dictionary.
    /// </summary>
    private void PopulateBoard()
    {

        // Loop through each tile type
        foreach (var tilePrefabData in tilePrefabs)
        {
            // Add each type of tile, as many times as specified in the Dictionary
            for (int i = 0; i < tilePrefabData.count; i++)
            {
                var tilePos = (Vector3)_tilePositions[Random.Range(0, _tilePositions.Count)];
                GameObject createdTile = CreateTile(tilePrefabData.tilePrefab, tilePos);
                _tilePositions.Remove(tilePos); // Remove the position from the list

                if (tilePrefabData.tilePrefab != desertTile)
                {
                    _tileDictionary[tilePos] = createdTile;
                }
            }
        }

        // Loop through each created tile (excluding desert tile)
        foreach (var tile in _tileDictionary.Values)
        {
            // Get a random numberPrefabData, and remove it from the list of numberPrefabs
            int randomIndex = Random.Range(0, numberPrefabs.Count);
            NumberPrefabData randomPair = numberPrefabs[randomIndex];
            numberPrefabs[randomIndex].count--;
            
            // Create the number token on top of the tile
            Vector3 numberPosition = tile.transform.position;
            GameObject createdNumber = CreateTile(randomPair.numberPrefab, numberPosition);
            
            // Get TileData component from the tile and assign the number
            var tileData = tile.GetComponent<TileData>();
            tileData.Initialize(createdNumber.GetComponent<NumberData>());

            // Remove the number token from the dictionary if its count reaches zero
            if (randomPair.count == 0)
            {
                numberPrefabs.RemoveAt(randomIndex);
            }
        }
    }

    /// <summary>
    /// Creates a new tile of the specified type and assigns it to the given position.
    /// </summary>
    /// <param name="tileType">The type of tile to create.</param>
    /// <param name="position">The position where the tile will be placed.</param>
    /// <returns>A new GameObject instance of the created tile.</returns>
    private GameObject CreateTile(GameObject tileType, Vector3 position)
    {
        var newTile = Instantiate(tileType);
        newTile.transform.position = position; //Move the cloned tile to the position picked
        return newTile;
    }
    
    /// <summary>
    /// Assigns adjacent tiles to each building point on the game board.
    /// A tile is considered adjacent if its distance to the building point is less than or equal to the adjacencyThreshold.
    /// </summary>
    /// <param name="adjacencyThreshold">The maximum distance between a building point and a tile for them to be considered adjacent.</param>
    private void AssignAdjacentTilesToBuildingPoints(float adjacencyThreshold = 0.6f)
    {
        for (int i = 0; i < buildingPointsHolder.childCount; i++)
        {
            var buildingPoint = buildingPointsHolder.GetChild(i).GetComponent<BuildingPoint>();
            foreach (var tileObject in _tileDictionary.Values)
            {
                if (Vector3.Distance(tileObject.transform.position, buildingPoint.transform.position) <= adjacencyThreshold)
                {
                    buildingPoint.GetAdjacentTiles().Add(tileObject);
                }
            }
        }
    }

    /// <summary>
    /// Gets the tile dictionary containing the positions and GameObjects of the generated tiles.
    /// </summary>
    /// <returns>The tile dictionary.</returns>
    public Dictionary<Vector3, GameObject> GetTileDictionary()
    {
        return _tileDictionary;
    }

    /// <summary>
    /// Data class that holds information about a tile prefab and the number of times it should be created.
    /// </summary>
    [System.Serializable]
    private class TilePrefabData
    {
        public GameObject tilePrefab;
        public int count;
    }

    /// <summary>
    /// Data class that holds information about a number token prefab and the number of times it should be created.
    /// </summary>
    [System.Serializable]
    private class NumberPrefabData
    {
        public GameObject numberPrefab;
        public int count;
    }
    
}
