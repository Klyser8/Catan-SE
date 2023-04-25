using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TradePlayerResources : MonoBehaviour
{
    public Button button_brick;
    public Button button_ore;
    public Button button_sheep;
    public Button button_wood;
    public Button button_wheat;

    public HandController hand;

    public Button button_brickPort;
    public Button button_orePort;
    public Button button_sheepPort;
    public Button button_woodPort;
    public Button button_wheatPort;
    public Button button_anyPort;

    public GameObject[] port;

    public GetResources getRes;
    private string resourseTypeToDiscard;

    private void Start() {
        
    }


    public void PortTrade(string[] playersPortType) {
        for(int i = 0; i < port.Length; i++) {
            for(int t = 0; t < playersPortType.Length; t++) {
                if(port[i].name == playersPortType[t]){
                    if(port[i].name == "BrickPort") {
                        button_brickPort.interactable = true;
                    }
                    else if(port[i].name == "OrePort") {
                        button_orePort.interactable = true;
                    }
                    else if(port[i].name == "SheepPort") {
                        button_sheepPort.interactable = true;
                    }
                    else if(port[i].name == "WoodPort") {
                        button_woodPort.interactable = true;
                    }
                    else if(port[i].name == "WheatPort") {
                        button_wheatPort.interactable = true;
                    }
                    else if(port[i].name == "AnyPort") {
                        button_anyPort.interactable = true;
                    }
                }
            }   
        }
    }

    public void CountedResources(string typeOfResourse) {
        Debug.Log("CountedResources called with Type: " + typeOfResourse);
    
        if (typeOfResourse == "Brick(Clone)") {
            button_brick.interactable = true;
            Debug.Log("Brick button activated");
            typeOfResourse = null;
        } else if (typeOfResourse == "Ore(Clone)") {
            button_ore.interactable = true;
            Debug.Log("Ore button activated");
            typeOfResourse = null;
        } else if (typeOfResourse == "Sheep(Clone)") {
            button_sheep.interactable = true;
            Debug.Log("Sheep button activated");
            typeOfResourse = null;
        } else if (typeOfResourse == "Wood(Clone)") {
            button_wood.interactable = true;
            Debug.Log("Wood button activated");
            typeOfResourse = null;
        } else if (typeOfResourse == "Wheat(Clone)") {
            button_wheat.interactable = true;
            Debug.Log("Wheat button activated");
            typeOfResourse = null;
        } else {
            Debug.Log("No matching resource type found");
            button_brick.interactable = false;
            button_ore.interactable = false;
            button_sheep.interactable = false;
            button_wood.interactable = false;
            button_wheat.interactable = false;

            typeOfResourse = null;
        }
    }

    public void ResourceToDiscard(string resourceToGive) {
        resourseTypeToDiscard = resourceToGive;
        CountedResources("Nothing");
    }

    public void DiscardBrick() {
        ResourceToDiscard("Brick(Clone)");
    }

    public void DiscardOre() {
        ResourceToDiscard("Ore(Clone)");
    }
    
    public void DiscardSheep() {
        ResourceToDiscard("Sheep(Clone)");
    }
    
    public void DiscardWood() {
        ResourceToDiscard("Wood(Clone)");
    }
    
    public void DiscardWheat() {
        ResourceToDiscard("Wheat(Clone)");
    }
//////////////////////////////////////////////////////////////////////////////////////
    public void TakeResource(int resourceIndex) { 
        CountedResources("Nothing");
        hand.EnableTransaction(resourseTypeToDiscard, resourceIndex, true);
    }

    public void TakeBrick() {
        TakeResource(0);
    }

    public void TakeOre() {
        TakeResource(1);
    }
    
    public void TakeSheep() {
        TakeResource(2);
    }
    
    public void TakeWheat() {
        TakeResource(3);
    }
    
    public void TakeWood() {
        TakeResource(4);
    }  
}
