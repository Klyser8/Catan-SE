using System;
using System.Collections;
using System.Collections.Generic;
using Action;
using Player;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class GameManager : MonoBehaviour
{

    private PlayerManager _playerManager;
    private DiceController _diceController;
    private TurnState _turnState = TurnState.GameStart;
    private int _lastRoll = 0;
    private PlayerController _currentPlayer;

    private void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _diceController = FindObjectOfType<DiceController>();
        Debug.Log("Number of players found: " + _playerManager.playerCount);
    }

    private void Update()
{
    switch (_turnState)
    {
        case TurnState.GameStart:
            Debug.Log("Game start");
            SwitchState(TurnState.WaitingForRoll);
            _currentPlayer = _playerManager.GetCurrentPlayer();
            break;
        
        case TurnState.WaitingForRoll:
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SwitchState(TurnState.Rolling);
            }
            break;
        
        case TurnState.Rolling:
            _diceController.RollDice();
            Debug.Log(_currentPlayer + " rolled a " + _lastRoll);
            if (_lastRoll != 7)
                SwitchState(TurnState.HarvestingResources);
            else
                SwitchState(TurnState.MovingRobber);
            break;
        
        case TurnState.HarvestingResources:
            Debug.Log("Harvesting resources");
            //TODO: Harvest resources based on the last roll
            SwitchState(TurnState.WaitingForAction);
            break;
        
        case TurnState.MovingRobber:
            Debug.Log(_currentPlayer + " is moving the robber");
            //TODO: Move the robber and steal resources from a player
            SwitchState(TurnState.WaitingForAction);
            break;
        
        case TurnState.WaitingForAction:
            HandleActionInput();
            break;
        
        case TurnState.Building:
            Debug.Log(_currentPlayer + " is building");
            SwitchState(TurnState.WaitingForAction);
            break;
        
        case TurnState.Trading:
            Debug.Log(_currentPlayer + " is trading");
            SwitchState(TurnState.WaitingForAction);
            break;
        
        case TurnState.BuyingDevelopmentCard:
            Debug.Log(_currentPlayer + " is buying a development card");
            SwitchState(TurnState.WaitingForAction);
            break;
        
        case TurnState.PlayingDevelopmentCard:
            Debug.Log(_currentPlayer + " is playing a development card");
            SwitchState(TurnState.WaitingForAction);
            break;

        case TurnState.EndTurn:
            Debug.Log(_currentPlayer + " is ending their turn");
            if (_currentPlayer.GetVictoryPoints() >= 10)
            {
                Debug.Log(_currentPlayer + " has won the game!");
                SwitchState(TurnState.EndGame);
            }
            _playerManager.NextTurn();
            _currentPlayer = _playerManager.GetCurrentPlayer();
            SwitchState(TurnState.WaitingForRoll);
            break;
        
        case TurnState.EndGame:
            Debug.Log("Game over");
            break;
    }
}

    private bool SwitchState(TurnState newState)
    {
        if (_turnState != newState)
        {
            TurnState oldState = _turnState;
            _turnState = newState;
            Debug.Log("Switching from " + oldState + " to " + newState);
            return true;
        }
        return false;
    }

    private void HandleActionInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _turnState = TurnState.EndTurn;
        } else if (Input.GetKeyDown(KeyCode.B)) //B for build
        {
            _turnState = TurnState.Building;
        } else if (Input.GetKeyDown(KeyCode.T)) //T for trade
        {
            _turnState = TurnState.Trading;
        } else if (Input.GetKeyDown(KeyCode.N)) //N for new card
        {
            _turnState = TurnState.BuyingDevelopmentCard;  
        } else if (Input.GetKeyDown(KeyCode.C)) //C for card
        {
            _turnState = TurnState.PlayingDevelopmentCard;
        }
    }
    
    
    public void CollectResources()
    {
        foreach (var player in _playerManager.GetPlayerControllers())
        {
            foreach (var building in player.GetBuildings())
            {
                
            }
        }
    }
}

public enum TurnState {
    GameStart,              // The game is starting.
    WaitingForRoll,         // The game is waiting for the player to roll the dice.
    Rolling,                // The player is rolling the dice to determine resource harvesting.
    HarvestingResources,    // The player is collecting resources based on the outcome of the dice roll.
    MovingRobber,           // The player is moving the robber to a new location on the board.
    WaitingForAction,       // The player is waiting to either Build, Buy Development Card, Play Development Card, or Trade.
    Building,               // The player is building a road, settlement, or city on the board.
    BuyingDevelopmentCard,  // The player is buying a development card from the bank.
    PlayingDevelopmentCard, // The player is playing a development card from their hand.
    Trading,                // The player is trading resources with other players.
    EndTurn,                // The player has completed their turn and the game moves on to the next player.
    EndGame                 // The game is over and the winner is declared.
}
