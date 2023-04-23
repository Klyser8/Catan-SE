using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryPointsWriter : MonoBehaviour
{
    public GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < players.Length; i++) {
            players[i].GetComponentInChildren<TextMeshProUGUI>().text = "0";
        }
    }

    public void AddScore(float score, int playerIndex)
    {
        string currentScore = players[playerIndex].GetComponentInChildren<TextMeshProUGUI>().text;
        float lastScore;
        bool success = float.TryParse(currentScore, out lastScore);

        if (success)
        {
            float newScore = lastScore + score;
            Debug.Log(newScore);
            // Update the TextMeshProUGUI with the new score
            players[playerIndex].GetComponentInChildren<TextMeshProUGUI>().text = newScore.ToString();
        }
        else
        {
            Debug.LogError("Failed to parse current score to float.");
        }
    }
}
