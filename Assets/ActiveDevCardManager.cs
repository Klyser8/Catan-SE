using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ActiveDevCardManager class handles the logic for playing and returning development cards.
/// </summary>
public class ActiveDevCardManager : MonoBehaviour
{
    int index = 1;
    public Transform hand;

    /// <summary>
    /// Plays the development card at the specified index by removing it from the player's hand.
    /// </summary>
    public void PlayCard()
    {
        // Check if the index is valid
        if (index >= 0 && index < this.transform.childCount)
        {
            // Get the child object at the specified index
            Transform childTransform = this.transform.GetChild(index);
            childTransform.SetParent(null);
            Destroy(childTransform.gameObject);
        }
    }

    /// <summary>
    /// Returns the development card at the specified index to the player's hand.
    /// </summary>
    public void ReturnCard()
    {
        if (index >= 0 && index < this.transform.childCount)
        {
            Transform childTransform = this.transform.GetChild(index);
            childTransform.SetParent(hand);
        }
    }
}
