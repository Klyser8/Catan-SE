using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class GameManager : MonoBehaviour
{
    
    public List<PlayerController> players;
    private int _currentPlayer = 1;
    private TurnState _turnState = TurnState.GameStart;
    
    private void Start()
    {
        players = new List<PlayerController>(FindObjectsOfType<PlayerController>());
        Debug.Log("Number of players found: " + players);
    }
    private void Update()
    {
        var playerController = players[_currentPlayer];
    }
    
    private int RollDice()
    {
        int result = UnityEngine.Random.Range(1, 7) + UnityEngine.Random.Range(1, 7);
        Debug.Log("Player " + _currentPlayer + " rolled a " + result);
        return result;
    }
    
    // Method to advance the turn to the next player
    public void NextTurn()
    {
        // Increment the current player index
        _currentPlayer++;

        // If we've reached the end of the list, loop back to the beginning
        if (_currentPlayer > players.Count)
        {
            _currentPlayer = 1;
        }
        //TODO: Perform any other actions that need to happen at the end of a turn
    }
}

public enum TurnState {
    GameStart,              // The game is starting.
    WaitingForRoll,         // The game is waiting for the player to roll the dice.
    Rolling,                // The player is rolling the dice to determine resource harvesting.
    HarvestingResources,    // The player is collecting resources based on the outcome of the dice roll.
    MovingRobber,           // The player is moving the robber to a new location on the board.
    Building,               // The player is building a road, settlement, or city on the board.
    BuyingDevelopmentCard,  // The player is buying a development card from the bank.
    PlayingDevelopmentCard, // The player is playing a development card from their hand.
    Trading,                // The player is trading resources with other players.
    EndTurn,                // The player has completed their turn and the game moves on to the next player.
    EndGame                 // The game is over and the winner is declared.
}
