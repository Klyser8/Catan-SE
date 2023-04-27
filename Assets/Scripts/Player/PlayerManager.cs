using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

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
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        // Instantiate the players
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
    
    /**
     * Advances the turn to the next player.
     * If the end of the round is reached, returns true.
     * A round is over when the next turn player is the first player.
     */
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

    public int GetCurrentPlayerID() 
    {
        return _currentPlayerId;
    }
    
    /**
     * Returns a list of all player controllers
     */
    public List<PlayerController> GetPlayers()
    {
        return _playerControllers;
    }
    
    public PlayerController GetCurrentPlayer() 
    {
        return _playerControllers[_currentPlayerId];
    }
    
    public int GetPlayerCount()
    {
        return playerCount;
    }

}

