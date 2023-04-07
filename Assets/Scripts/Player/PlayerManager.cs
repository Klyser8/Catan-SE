using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab; // Assign the player prefab in the editor
    public int playerCount = 4;
    private List<PlayerController> _playerControllers = new();
    private int _currentPlayer = 0;

    private ArrayList _playerPositions = new()
    {
        new Vector3(3, 1, 0),
        new Vector3(0, 1, -3),
        new Vector3(-3, 1, 0),
        new Vector3(0, 1, 3),
    };
    
    void Start()
    {
        // Instantiate the players
        for (var i = 0; i < playerCount; i++)
        {
            var player = Instantiate(playerPrefab, (Vector3) _playerPositions[i], Quaternion.identity);
            player.name = "Player " + (i + 1);
            PlayerController playerController = player.GetComponent<PlayerController>();
            _playerControllers.Add(playerController);
            player.transform.SetParent(transform, this);
        }
    }
    
    // Method to advance the turn to the next player
    public void NextTurn()
    {
        _currentPlayer++;

        // If we've reached the end of the list, loop back to the beginning
        if (_currentPlayer >= playerCount)
        {
            _currentPlayer = 0;
        }
        //TODO: Perform any other actions that need to happen at the end of a turn
    }
    
    /**
     * Returns a list of all player controllers
     */
    public List<PlayerController> GetPlayerControllers()
    {
        return _playerControllers;
    }
    
    public PlayerController GetCurrentPlayer() 
    {
        return _playerControllers[_currentPlayer];
    }

}

