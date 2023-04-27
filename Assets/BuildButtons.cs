using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.UI;

public class BuildButtons : MonoBehaviour
{
    public Button road;
    public Button settlement;
    public Button city;
    public Button devCard;

    private BuildHandler buildHandler;

    private PlayerManager _playerManager;

    private void Start() {
        _playerManager = FindObjectOfType<PlayerManager>();
        buildHandler = FindObjectOfType<BuildHandler>();
        ActivateButtons();
    }

    public void ActivateButtons() {
        var player = _playerManager.GetCurrentPlayer();
        road.interactable = false;
        settlement.interactable = false;
        city.interactable = false;
        devCard.interactable = false;
        if(player.GetResourceHandler().HasResources(1, 0, 1, 0, 0)) {
            road.interactable = true;
        }
        if(player.GetResourceHandler().HasResources(1, 1, 1, 0, 1)) {
            settlement.interactable = true;
        }
        if(player.GetResourceHandler().HasResources(0, 2, 0, 3, 0)) {
            city.interactable = true;
        }
        if(player.GetResourceHandler().HasResources(0, 1, 0, 1, 1)) {
            devCard.interactable = true;
        }
        Debug.Log(road.interactable + " " + settlement.interactable + " " + city.interactable + " " + devCard.interactable);
    }

    public void MouseClickBlock(int buildIndex) {
        if(buildIndex == 0) {
            Unblock();
            buildHandler.TypeOfBuilding(0);
            
        }
        if(buildIndex == 1) {
            Unblock();
            buildHandler.TypeOfBuilding(1);
            
        }
        if(buildIndex == 2) {
            Unblock();
            buildHandler.TypeOfBuilding(2);
            
        }
        if(buildIndex == 3) {
            Unblock();
            buildHandler.TypeOfBuilding(3);
        }
        DeactivateButtons();
    }

    public bool Unblock() {
        return true;
    }

    public void DeactivateButtons() {
        road.interactable = false;
        settlement.interactable = false;
        city.interactable = false;
        devCard.interactable = false;
    }

    public void BuildRoad() {
        MouseClickBlock(0);
    }

    public void BuildSettlement() {
        MouseClickBlock(1);
    }
    
    public void BuildCity() {
        MouseClickBlock(2);
    }
    
    public void BuildDevCard() {
        MouseClickBlock(3);
    }
}
