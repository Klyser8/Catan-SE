using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

/// <summary>
/// The `PlayerManager` class manages the players in the game.
/// It provides access to player-related information and actions.
/// This script is NOT used to store player data, but rather to manage the players in the game in a more general manner.
/// </summary>
[DefaultExecutionOrder(-1)]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab; // Assign the player prefab in the editor
    [SerializeField] private int playerCount = 4;
    [SerializeField] private List<Material> colorMaterials;
    
    private GameManager _gameManager;
    private List<PlayerController> _playerControllers = new();
    private int _currentPlayerId;

    private ArrayList _playerPositions = new()
    {
        new Vector3(3, 1, 0),
        new Vector3(0, 1, -3),
        new Vector3(-3, 1, 0),
        new Vector3(0, 1, 3),
    };
    
    /// <summary>
    /// Initializes the game manager and players.
    /// </summary>
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        InitializePlayers();
    }

    /// <summary>
    /// Initializes the players in the game.
    /// </summary>
    private void InitializePlayers()
    {
        for (var i = 0; i < playerCount; i++)
        {
            var player = Instantiate(playerPrefab, (Vector3) _playerPositions[i], Quaternion.identity);
            player.name = "Player " + (i + 1);
            PlayerController playerController = player.GetComponent<PlayerController>();
            playerController.Initialize(colorMaterials[i]);
            _playerControllers.Add(playerController);
            player.transform.SetParent(transform, this);
        }
    }
    
    /// <summary>
    /// Advances the turn to the next player in the game.
    /// If the game is in the initial placement phase, it advances the turn in a specific order.
    /// Otherwise, it advances normally.
    /// </summary>
    /// <returns>A boolean indicating if the current round has ended or not.</returns>
    public bool AdvanceTurn()
    {
        bool endOfRound = false;

        if (_gameManager.GetGameState() == GameState.InitialPlacement)
        {
            if (_gameManager.GetCurrentRound() == -1)
            {
                _currentPlayerId++;

                if (_currentPlayerId >= playerCount)
                {
                    _currentPlayerId = playerCount - 1;
                    endOfRound = true;
                }
            }
            else if (_gameManager.GetCurrentRound() == 0)
            {
                _currentPlayerId--;

                if (_currentPlayerId < 0)
                {
                    _currentPlayerId = 0;
                    endOfRound = true;
                }
            }
        }
        else
        {
            _currentPlayerId++;

            // If we've reached the end of the list, loop back to the beginning
            if (_currentPlayerId >= playerCount)
            {
                _currentPlayerId = 0;
                endOfRound = true;
            }
        }

        return endOfRound;
    }
    
    /// <summary>
    /// Returns a list of all player controllers.
    /// </summary>
    /// <returns>A list of player controllers.</returns>
    public List<PlayerController> GetPlayers()
    {
        return _playerControllers;
    }
    
    /// <summary>
    /// Returns the player controller of the player who's turn it is.
    /// </summary>
    /// <returns>The player controller of the current player.</returns>
    public PlayerController GetCurrentPlayer() 
    {
        return _playerControllers[_currentPlayerId];
    }
    
    /// <summary>
    /// Returns the number of players in the game.
    /// </summary>
    /// <returns>The number of players in the game.</returns>
    public int GetPlayerCount()
    {
        return playerCount;
    }

}

