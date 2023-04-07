using System.Collections;
using System.Collections.Generic;
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

    private Vector3 desertNoNumber;
    
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
        PopulateNumbers();
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
        //Loop through each tile type
        foreach (var tileType in tiles.Keys)
        {
            //Add each type of tile, as many times as specified in the Dictionary.
            for (int i = 0; i < tiles[tileType]; i++)
            {
                var pos = (Vector3)_tilePositions[Random.Range(0, _tilePositions.Count)];
                CreateTile(tileType, pos);
                if(tileType == desertTile) {
                    desertNoNumber = pos;
                }
                _tilePositions.Remove(pos); //Remove the position from the list
            }
        }
    }

    void PopulateNumbers()
    {
        // Debug.Log("Desert Position: " + desertNoNumber);
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
        //Loop through each tile type
        foreach (var numType in numbers.Keys)
        {
            //Add each type of tile, as many times as specified in the Dictionary.
            for (int i = 0; i < numbers[numType]; i++)
            {
                var pos = (Vector3)_numPositions[Random.Range(0, _numPositions.Count)];
                
                // Debug.Log(numType + " " + pos);
                if(pos == desertNoNumber){
                    _numPositions.Remove(pos);
                    pos = (Vector3)_numPositions[Random.Range(0, _numPositions.Count)];
                }
                CreateTile(numType, pos);
                _numPositions.Remove(pos); //Remove the position from the list
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
