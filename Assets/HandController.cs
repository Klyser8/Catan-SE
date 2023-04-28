using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HandController class handles the logic for managing the player's hand, including counting cards,
/// activating buttons, and interacting with the bank.
/// </summary>
public class HandController : MonoBehaviour
{
    public GameObject hand;
    public TradePlayerResources toTrade;
    public int cardsValue;
    public GetResources getRes;
    private BuildButtons buildButtons;

    /// <summary>
    /// Called once per frame.
    /// </summary>
    private void Update()
    {
        if (hand.transform.childCount != cardsValue)
        {
            buildButtons = FindObjectOfType<BuildButtons>();
            buildButtons.ActivateButtons();
            CountCardsInHand();
            cardsValue = hand.transform.childCount;
        }
    }

    /// <summary>
    /// Counts the number of cards in the player's hand and checks if they can trade.
    /// </summary>
    public void CountCardsInHand()
    {
        if (hand.transform.childCount > 0)
        {
            List<string> counted = new List<string>();

            for (int i = 0; i < hand.transform.childCount; i++)
            {
                string childName = hand.transform.GetChild(i).gameObject.name;

                if (!counted.Contains(childName))
                {
                    int resourceCounter = 0;

                    for (int z = 0; z < hand.transform.childCount; z++)
                    {
                        if (childName == hand.transform.GetChild(z).gameObject.name)
                        {
                            resourceCounter++;
                        }
                    }
                    if (resourceCounter >= 4)
                    {
                        toTrade.CountedResources(childName);
                    }
                    else
                    {
                        toTrade.CountedResources("Nothing");
                    }
                    counted.Add(childName);
                }
            }
        }
    }

    /// <summary>
    /// Gives the specified amount of resources with the given name to the bank.
    /// </summary>
    /// <param name="amountToDiscard">The number of resources to give to the bank.</param>
    /// <param name="resourceName">The name of the resource to give to the bank.</param>
    public void GiveToBank(int amountToDiscard, string resourceName)
    {
        GameObject resourceToDiscard;
        for (int i = 0; i < amountToDiscard; i++)
        {
            resourceToDiscard = hand.transform.GetChild(i).gameObject;
            if (resourceToDiscard.name == resourceName)
            {
                Destroy(resourceToDiscard);
            }
        }
    }
}





