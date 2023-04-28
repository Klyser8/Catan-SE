using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using TMPro;

/// <summary>
/// This script is responsible for managing and displaying the victory points of each player.
/// </summary>
[DefaultExecutionOrder(0)]
public class VictoryPointsWriter : MonoBehaviour
{
    private PlayerManager _playerManager;
    public GameObject[] playersInfo;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        UpdateVictoryPointsText();
    }
    
    /// <summary>
    /// Add the specified score to the player's victory points and update the UI.
    /// </summary>
    /// <param name="score">The score to be added.</param>
    /// <param name="playerIndex">The index of the player to add the score to.</param>
    public void AddScore(int score, int playerIndex)
    {
        _playerManager.GetPlayers()[playerIndex].AddVictoryPoints(score);
        Debug.Log(_playerManager.GetCurrentPlayer().name + " GET VP");
        UpdateVictoryPointsText();
    }

    /// <summary>
    /// Update the victory points text for all players in the UI.
    /// </summary>
    private void UpdateVictoryPointsText()
    {
        foreach (var player in _playerManager.GetPlayers())
        {
            int victoryPoints = player.GetVictoryPoints();
            player.GetPlayerPanel().transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = victoryPoints.ToString(); 
        }
    }
}

