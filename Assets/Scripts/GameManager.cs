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
    private GameState _gameState = GameState.GameStart;
    private int _roundCounter = -1;
    private void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _diceController = FindObjectOfType<DiceController>();
        Debug.Log("Number of players found: " + _playerManager.GetPlayerCount());
    }

    /**
     * Main game cycle
     */
    private void Update()
{
    switch (_gameState)
    {
        case GameState.GameStart:
            Debug.Log("Game start");
            SwitchState(GameState.InitialPlacement);
            break;
        
        case GameState.InitialPlacement:
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_playerManager.AdvanceTurn())
                {
                    _roundCounter++;
                    Debug.Log("Round " + _roundCounter + " is over");
                } //TODO refactor this code in a method
                Debug.Log("Round " + _roundCounter + ": "+ _playerManager.GetCurrentPlayer() + " is starting their turn");
                if (_roundCounter == 1)
                {
                    SwitchState(GameState.WaitingForRoll);
                }
            }
            break;
        
        case GameState.WaitingForRoll:
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SwitchState(GameState.Rolling);
            }
            break;
        
        case GameState.Rolling:
            _diceController.RollDice();
            Debug.Log(_playerManager.GetCurrentPlayer() + " rolled a " + _diceController.GetLastRoll());
            if (_diceController.GetLastRoll() != 7)
                SwitchState(GameState.HarvestingResources);
            else
                SwitchState(GameState.MovingRobber);
            break;
        
        case GameState.HarvestingResources:
            Debug.Log("Harvesting resources");
            //TODO: Harvest resources based on the last roll
            SwitchState(GameState.WaitingForAction);
            break;
        
        case GameState.MovingRobber:
            Debug.Log(_playerManager.GetCurrentPlayer() + " is moving the robber");
            //TODO: Move the robber and steal resources from a player
            SwitchState(GameState.WaitingForAction);
            break;
        
        case GameState.WaitingForAction:
            HandleActionInput();
            break;
        
        case GameState.Building:
            Debug.Log(_playerManager.GetCurrentPlayer() + " is building");
            SwitchState(GameState.WaitingForAction);
            break;
        
        case GameState.Trading:
            Debug.Log(_playerManager.GetCurrentPlayer() + " is trading");
            SwitchState(GameState.WaitingForAction);
            break;
        
        case GameState.BuyingDevelopmentCard:
            Debug.Log(_playerManager.GetCurrentPlayer() + " is buying a development card");
            SwitchState(GameState.WaitingForAction);
            break;
        
        case GameState.PlayingDevelopmentCard:
            Debug.Log(_playerManager.GetCurrentPlayer() + " is playing a development card");
            SwitchState(GameState.WaitingForAction);
            break;

        case GameState.EndTurn:
            Debug.Log(_playerManager.GetCurrentPlayer() + " is ending their turn");
            if (_playerManager.GetCurrentPlayer().GetVictoryPoints() >= 10)
            {
                Debug.Log(_playerManager.GetCurrentPlayer() + " has won the game!");
                SwitchState(GameState.EndGame);
            }
            if (_playerManager.AdvanceTurn())
            {
                _roundCounter++;
                Debug.Log("Round " + _roundCounter + " is over");
            }
            Debug.Log("Round " + _roundCounter + ": "+ _playerManager.GetCurrentPlayer() + " is starting their turn");
            if (_roundCounter > 0)
            {
                SwitchState(GameState.WaitingForRoll);
            }
            else
            {
                SwitchState(GameState.InitialPlacement);
            }

            break;
        
        case GameState.EndGame:
            Debug.Log("Game over");
            break;
    }
}

    /**
     * Switches the game state to the a new state.
     * Mostly used for debugging purposes.
     */
    private bool SwitchState(GameState newState)
    {
        if (_gameState != newState)
        {
            GameState oldState = _gameState;
            _gameState = newState;
            Debug.Log("Switching from " + oldState + " to " + newState);
            return true;
        }
        return false;
    }

    /**
     * Handles the input for the player's actions.
     * This should be replaced with input from the UI.
     */
    private void HandleActionInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _gameState = GameState.EndTurn;
        } else if (Input.GetKeyDown(KeyCode.B)) //B for build
        {
            _gameState = GameState.Building;
        } else if (Input.GetKeyDown(KeyCode.T)) //T for trade
        {
            _gameState = GameState.Trading;
        } else if (Input.GetKeyDown(KeyCode.N)) //N for new card
        {
            _gameState = GameState.BuyingDevelopmentCard;  
        } else if (Input.GetKeyDown(KeyCode.C)) //C for card
        {
            _gameState = GameState.PlayingDevelopmentCard;
        }
    }
    
    /**
     * Provides the players with the resources found near their settlements and cities.
     * This method should be called when the dice are rolled and the number rolled is not 7.
     * It should also be called at the start of the game,
     * when the players are given their initial resources from the second settlements they placed.
     */
    public void CollectResources()
    {
        foreach (var player in _playerManager.GetPlayers())
        {
            foreach (var building in player.GetBuildings())
            {
                
            }
        }
    }

    public int GetCurrentRound()
    {
        return _roundCounter;
    }
    
    public GameState GetGameState()
    {
        return _gameState;
    }
    
}

/**
 * The TurnState enum is used to keep track of the current state of the game.
 */
public enum GameState {
    GameStart,              // The game is starting.
    InitialPlacement,       // The players are placing their initial settlements and roads.
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
