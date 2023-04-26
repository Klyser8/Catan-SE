using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using TMPro;

public class VictoryPointsWriter : MonoBehaviour
{
    private PlayerManager _playerManager;
    // Start is called before the first frame update
    void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        UpdateVictoryPointsText();
    }
    
    public void AddScore(int score, int playerIndex)
    {
        _playerManager.getPlayers()[playerIndex].AddVictoryPoints(score);
        UpdateVictoryPointsText();
    }

    private void UpdateVictoryPointsText()
    {
        foreach (var player in _playerManager.getPlayers())
        {
            int victoryPoints = player.GetVictoryPoints();
            player.GetComponentInChildren<TextMeshProUGUI>().text = victoryPoints.ToString();
        }
    }
}
