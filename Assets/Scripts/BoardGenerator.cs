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
    
    ArrayList _tilePositions = new()
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

    ArrayList _numPositions = new()
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

    // Start is called before the first frame update
    void Start()
    {
        PopulateBoard();
        // PopulateNumbers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PopulateBoard()
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
        List<GameObject> createdTiles = new List<GameObject>();

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
                    createdTiles.Add(createdTile);
                }
            }
        }

        // Loop through each created tile (excluding desert tile)
        foreach (var tile in createdTiles)
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

    GameObject CreateTile(GameObject tileType, Vector3 position)
    {
        var newTile = Instantiate(tileType);
        newTile.transform.position = position; //Move the cloned tile to the position picked
        return newTile;
    }
}
