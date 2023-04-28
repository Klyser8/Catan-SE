using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GetResources class handles the logic for instantiating and adding resources to the player's hand.
/// </summary>
public class GetResources : MonoBehaviour
{
    public GameObject hand;
    public GameObject[] resources;

    // Brick 0
    // Ore 1
    // Sheep 2
    // Wheat 3
    // Wood 4

    /// <summary>
    /// Instantiates the specified number of resources and adds them to the player's hand.
    /// </summary>
    /// <param name="numberOfResources">The number of resources to instantiate.</param>
    /// <param name="indexOfResource">The index of the resource type to instantiate.</param>
    public void TakeResources(int numberOfResources, int indexOfResource)
    {
        for (int i = 0; i < numberOfResources; i++)
        {
            GameObject newResource = Instantiate(resources[indexOfResource], hand.transform, true);
        }
    }
}



