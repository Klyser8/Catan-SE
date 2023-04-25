using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player; // Add this line to include the Player namespace

public class GetResources : MonoBehaviour
{
    public GameObject hand;
    public GameObject[] resources;
    

    // Brick 0
    // Ore 1
    // Sheep 2
    // Wheat 3
    // Wood 4

    public void TakeResources(int numberOfResources, int indexOfResource) {
        for (int i = 0; i < numberOfResources; i++) {
            GameObject newResource = Instantiate(resources[indexOfResource]);
            newResource.transform.SetParent(hand.transform);
        }
    }
}


