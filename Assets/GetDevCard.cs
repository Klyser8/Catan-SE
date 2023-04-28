using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GetDevCard class handles the logic for instantiating and adding development cards to the player's hand.
/// </summary>
public class GetDevCard : MonoBehaviour
{
    public GameObject hand;
    public GameObject[] devCards;

    /// <summary>
    /// Instantiates the specified development card and adds it to the player's hand.
    /// </summary>
    /// <param name="devCardIndex">The index of the development card to instantiate.</param>
    public void TakeDevCard(int devCardIndex)
    {
        GameObject newDevCard = Instantiate(devCards[devCardIndex]);
        newDevCard.transform.SetParent(hand.transform);
    }
}

