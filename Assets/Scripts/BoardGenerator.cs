using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class BoardGenerator : MonoBehaviour
{
    public GameObject forestTile;
    public GameObject hayTile;
    public GameObject fieldTile;
    public GameObject clayTile;
    public GameObject oreTile;
    public GameObject desertTile;

    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject eight;
    public GameObject nine;
    public GameObject ten;
    public GameObject eleven;
    public GameObject twelve;

    private Vector3 desertPos;

    public RobberyController robbery;

    [SerializeField] private Transform buildingPointsHolder;
    
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

    private ArrayList _numPositions = new()
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

    void Update()
    {
        
    }

    /**
     * Populates the game board with tiles and their corresponding number tokens.
     * The method creates each type of tile (forest, hay, field, clay, ore, and desert)
     * based on the specified quantities and assigns random numbers to the tiles (excluding the desert tile).
     * The created tiles and their positions are stored in _tileDictionary.
     */
    private void PopulateBoard()
    {
        Dictionary<GameObject, int> tiles = new Dictionary<GameObject, int>
        {
            { forestTile, 4 },
            { hayTile, 4 },
            { fieldTile, 4 },
            { clayTile, 3 },
            { oreTile, 3 },
            { desertTile, 1 },
        };
        Dictionary<GameObject, int> numbers = new Dictionary<GameObject, int>
        {
            { two, 1 },
            { three, 2 },
            { four, 2 },
            { five, 2 },
            { six, 2 },
            { eight, 2 },
            { nine, 2 },
            { ten, 2 },
            { eleven, 2 },
            { twelve, 1 },
        };

        // Loop through each tile type
        foreach (var tileType in tiles.Keys)
        {
            // Add each type of tile, as many times as specified in the Dictionary
            for (int i = 0; i < tiles[tileType]; i++)
            {
                var tilePos = (Vector3)_tilePositions[Random.Range(0, _tilePositions.Count)];
                GameObject createdTile = CreateTile(tileType, tilePos);
            
                _tilePositions.Remove(tilePos); // Remove the position from the list

                if (tileType != desertTile)
                {
                    _tileDictionary[tilePos] = createdTile;
                }
            }
        }

        // Loop through each created tile (excluding desert tile)
        foreach (var tile in _tileDictionary.Values)
        {
            // Get a random number, and remove it from the list of numbers/counts
            int randomIndex = Random.Range(0, numbers.Count);
            KeyValuePair<GameObject, int> randomPair = numbers.ElementAt(randomIndex);
            numbers[randomPair.Key]--;

            // Get TileData component from the tile and assign the number
            var tileData = tile.GetComponent<TileData>();
            tileData.SetNumber(randomPair.Key);

            // Create the number token on top of the tile
            Vector3 numberPosition = tile.transform.position;
            CreateTile(randomPair.Key, numberPosition);

            // Remove the number token from the dictionary if its count reaches zero
            if (numbers[randomPair.Key] == 0)
            {
                numbers.Remove(randomPair.Key);
            }
        }
    }

    /**
     * Creates a new tile of the specified type and assigns it to the given position.
     *
     * @param tileType The type of tile to create (forest, hay, field, clay, ore, or desert).
     * @param The position where the tile will be placed.
     * @return A new GameObject instance of the created tile.
     */
    GameObject CreateTile(GameObject tileType, Vector3 position)
    {
        var newTile = Instantiate(tileType);
        newTile.transform.position = position; //Move the cloned tile to the position picked
        return newTile;
    }
    
    /**
     * Assigns adjacent tiles to each building point on the game board.
     * A tile is considered adjacent if its distance to the building point is less than or equal to the adjacencyThreshold.
     *
     * @param adjacencyThreshold The maximum distance between a building point and a
     *                           tile for them to be considered adjacent (default value is 0.6f).
     */
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

    public Dictionary<Vector3, GameObject> GetTileDictionary()
    {
        return _tileDictionary;
    }

}
