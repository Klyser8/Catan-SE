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
    
    ArrayList _tilePositions = new()
    {
        //Middle row
        new Vector3(-0.075f, 0.05f, -0.002f),
        new Vector3(-0.98f, 0.05f, -0.002f),
        new Vector3(-1.86f, 0.05f, -0.002f),
        new Vector3(0.8f, 0.05f, -0.002f),
        new Vector3(1.69f, 0.05f, -0.002f),
        //Left Row
        new Vector3(1.26f, 0.05f, 0.77f),
        new Vector3(0.36f, 0.05f, 0.77f),
        new Vector3(-0.53f, 0.05f, 0.77f),
        new Vector3(-1.43f, 0.05f, 0.77f),
        //Right Row
        new Vector3(-1.43f, 0.05f, -0.77f),
        new Vector3(-0.53f, 0.05f, -0.77f),
        new Vector3(0.36f, 0.05f, -0.77f),
        new Vector3(1.26f, 0.05f, -0.77f),
        //Left-Left Row
        new Vector3(0.81f, 0.05f, 1.55f),
        new Vector3(-0.09f, 0.05f, 1.55f),
        new Vector3(-0.98f, 0.05f, 1.55f),
        //Right-Right Row
        new Vector3(-0.98f, 0.05f, -1.55f),
        new Vector3(-0.09f, 0.05f, -1.55f),
        new Vector3(0.81f, 0.05f, -1.55f),
    };

    // Start is called before the first frame update
    void Start()
    {
        PopulateBoard();
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
                _tilePositions.Remove(pos); //Remove the position from the list
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
