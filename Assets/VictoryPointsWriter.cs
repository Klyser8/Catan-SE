using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using TMPro;

[DefaultExecutionOrder(0)]
public class VictoryPointsWriter : MonoBehaviour
{
    private PlayerManager _playerManager;
    public GameObject[] playersInfo;
    // Start is called before the first frame update
    void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        UpdateVictoryPointsText();
    }
    
    public void AddScore(int score, int playerIndex)
    {
        _playerManager.GetPlayers()[playerIndex].AddVictoryPoints(score);
        Debug.Log(_playerManager.GetCurrentPlayer().name + " GET VP");
        UpdateVictoryPointsText();
    }

    private void UpdateVictoryPointsText()
    {
        foreach (var player in _playerManager.GetPlayers())
        {
            int victoryPoints = player.GetVictoryPoints();
            player.GetPlayerPanel().transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = victoryPoints.ToString(); 
            // Debug.Log("something: " + player.GetComponentInChildren<TextMeshProUGUI>());
            // player.GetComponentInChildren<TextMeshProUGUI>().text = victoryPoints.ToString();
        }
    }
}
