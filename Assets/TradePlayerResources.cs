using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Player;

// Set the default execution order of the script to 2
[DefaultExecutionOrder(2)]
public class TradePlayerResources : MonoBehaviour
{
    // Define buttons for each type of resource
    public Button button_brick;
    public Button button_ore;
    public Button button_sheep;
    public Button button_wood;
    public Button button_wheat;
    
    // Get access to the player's hand, resources, and trade controls
    public HandController hand;
    public GetResources getRes;
    public PlayerController playerTrade;
    
    // Define buttons for each type of port
    public Button button_brickPort;
    public Button button_orePort;
    public Button button_sheepPort;
    public Button button_woodPort;
    public Button button_wheatPort;
    public Button button_anyPort;
    
    // Get access to the player's manager
    public PlayerManager playerManager;
    
    // Define an array to hold each port
    public GameObject[] port;
    
    // Define a variable to hold the resource type that the player wants to discard
    private string resourseTypeToDiscard;
    
    // Start is called before the first frame update
    private void Start() {
        // Get the current player from the player manager
        playerTrade = playerManager.GetCurrentPlayer();
        // If the player is null, print an error message
        if(playerTrade == null) {
            Debug.Log("Player is null");
        }
        // Otherwise, print a message that the player exists
        Debug.Log("Player exist");
    }
    
    // Activate the buttons for the specified types of ports
    public void PortTrade(string[] playersPortType) {
        // Loop through each port
        for(int i = 0; i < port.Length; i++) {
            // Loop through each type of port that the player has
            for(int t = 0; t < playersPortType.Length; t++) {
                // If the port is one of the types the player has, activate the corresponding button
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
    
    // Activate the button for the specified type of resource
    public void CountedResources(string typeOfResourse) {
        // Print a message indicating that the method has been called and the type of resource
        Debug.Log("CountedResources called with Type: " + typeOfResourse);
        // If the player is null, print an error message
        if(playerTrade == null) {
            Debug.Log("Player is null");
        }
        // Otherwise, print a message that the player exists
        Debug.Log("Player exist");
        // Depending on the type of resource, activate the corresponding button
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
            // If the type of resource doesn't match any of the specified types, deactivate all buttons
            Debug.Log("No matching resource type found");
            button_brick.interactable = false;
            button_ore.interactable = false;
            button_sheep.interactable = false;
            button_wood.interactable = false;
            button_wheat.interactable = false;
            typeOfResourse = null;
        }
    }
        
    // Set the resource type that the player wants to discard
    public void ResourceToDiscard(string resourceToGive) {
        resourseTypeToDiscard = resourceToGive;
    }
    
    
    // Take a specified amount of a specified resource from the bank and give it to the player
    public void TakeResourceFromBank(int resourceIndex, int amountToDiscard, bool enable) { 
        // If the trade is enabled
        if (enable) {
            // Get the player's resource handler
            ResourceHandler resHand = playerTrade.GetResourceHandler();
            // Print a message showing the resource index, amount to discard, and whether the trade is enabled
            Debug.Log(resourceIndex + " " + amountToDiscard + " " + enable);
            // Print the type of resource to discard
            Debug.Log(resourseTypeToDiscard);
            // Loop through the specified number of resources to discard
            for(int i = 0; i < amountToDiscard; i++) {
                // Depending on the type of resource to discard, subtract the appropriate resources from the player's hand
                if (resourseTypeToDiscard == "Brick(Clone)") {
                    resHand.SubtractResources(0, 0, 1, 0, 0);
                    Debug.Log(resourseTypeToDiscard + " Discarded");
                } else if (resourseTypeToDiscard == "Ore(Clone)") {
                    resHand.SubtractResources(0, 0, 0, 1, 0);
                    Debug.Log(resourseTypeToDiscard);
                } else if (resourseTypeToDiscard == "Sheep(Clone)") {
                    resHand.SubtractResources(0, 0, 0, 0, 1);
                    Debug.Log(resourseTypeToDiscard);
                } else if (resourseTypeToDiscard == "Wood(Clone)") {
                    resHand.SubtractResources(1, 0, 0, 0, 0);
                    Debug.Log(resourseTypeToDiscard);
                } else if (resourseTypeToDiscard == "Wheat(Clone)") {
                    resHand.SubtractResources(0, 1, 0, 0, 0);
                    Debug.Log(resourseTypeToDiscard);
                } else {
                    // If the type of resource to discard doesn't match any of the specified types, print an error message
                    Debug.LogError("Invalid resource name");
                }
            }
            // Depending on the resource index, add the appropriate resources to the player's hand
            if (resourceIndex == 0) {
                resHand.AddResources(0, 0, 1, 0, 0);
                getRes.TakeResources(1, 0);
            } else if (resourceIndex == 1) {
                resHand.AddResources(0, 0, 0, 1, 0);
                getRes.TakeResources(1, 1);
            } else if (resourceIndex == 2) {
                resHand.AddResources(0, 0, 0, 0, 1);
                getRes.TakeResources(1, 2);
            } else if (resourceIndex == 3) {
                resHand.AddResources(0, 1, 0, 0, 0);
                getRes.TakeResources(1, 3);
            } else if (resourceIndex == 4) {
                resHand.AddResources(1, 0, 0, 0, 0);
                getRes.TakeResources(1, 4);
            } else {
                // If the resource index is invalid, print an error message
                Debug.LogError("Invalid resource index");
            }
        }
        // Reset the resource buttons
        CountedResources("Nothing");
        enable = false;
    }

    // Set the resource type to discard as Brick
    public void DiscardBrick() {
        ResourceToDiscard("Brick(Clone)");
    }
    
    // Set the resource type to discard as Ore
    public void DiscardOre() {
        ResourceToDiscard("Ore(Clone)");
    }
    
    // Set the resource type to discard as Sheep
    public void DiscardSheep() {
        ResourceToDiscard("Sheep(Clone)");
    }
    
    // Set the resource type to discard as Wood
    public void DiscardWood() {
        ResourceToDiscard("Wood(Clone)");
    }
    
    // Set the resource type to discard as Wheat
    public void DiscardWheat() {
        ResourceToDiscard("Wheat(Clone)");
    }
    
    // Take 4 bricks from the bank and give them to the player
    public void TakeBrick() {
        TakeResourceFromBank(0, 4, true);
    }
    
    // Take 4 ores from the bank and give them to the player
    public void TakeOre() {
        TakeResourceFromBank(1, 4, true);
    }
    
    // Take 4 sheep from the bank and give them to the player
    public void TakeSheep() {
        TakeResourceFromBank(2, 4, true);
    }
    
    // Take 4 wheat from the bank and give them to the player
    public void TakeWheat() {
        TakeResourceFromBank(3, 4, true);
    }
    
    // Take 4 wood from the bank and give them to the player
    public void TakeWood() {
        TakeResourceFromBank(4, 4, true);
    }  
}