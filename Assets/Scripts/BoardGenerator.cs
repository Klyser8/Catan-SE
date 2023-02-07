using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{

    ArrayList tilePositions = new ArrayList() {
        Vector3 = new Vector3(-0.09, 0.2, -0.03)
    };



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject createTile()
    {
        GameObject emptyObject = new GameObject();
        emptyObject.name = "Empty Object";
        GameObject newAsset = Instantiate(assetToAdd, emptyObject.transform);
        newAsset.transform.parent = emptyObject.transform;
    }
}
