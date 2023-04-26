using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDevCard : MonoBehaviour
{
    public GameObject hand;

    public GameObject[] devCards;


    public void TakeDevCard(int devCardIndex) {
        
            GameObject newDevCard = Instantiate(devCards[devCardIndex]);
            newDevCard.transform.SetParent(hand.transform);
        
    } 
}
