using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandController : MonoBehaviour
{
    public GameObject hand;
    public TradePlayerResources toTrade;
    public int cardsValue;
    public GetResources getRes;

    private void Update()
    {
        if(hand.transform.childCount != cardsValue) {
            CountCardsInHand();
            cardsValue = hand.transform.childCount;
        }
    }

    public void CountCardsInHand() {
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
                    if(resourceCounter >= 4) {
                        toTrade.CountedResources(childName);
                    } else {
                        toTrade.CountedResources("Nothing");
                    }
                    counted.Add(childName);
                }
            }
        }
    }

    

    public void GiveToBank(int amountToDiscard, string resourceName) {
        GameObject resourceToDiscard;
        for(int i = 0; i < amountToDiscard; i++) {
            resourceToDiscard = hand.transform.GetChild(i).gameObject;
            if(resourceToDiscard.name == resourceName) {
                Destroy(resourceToDiscard);
            }
        }
    }
}




