using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Player
{
    /// <summary>
    /// PlayerPanel class handles setting up the player panels and testing the player panel setup.
    /// </summary>
    public class PlayerPanel : MonoBehaviour
    {
        public GameObject[] playersPanels;
        private PlayerManager playerManager;

        /// <summary>
        /// Initializes player panels on start.
        /// </summary>
        private void Start()
        {
            playerManager = FindObjectOfType<PlayerManager>();
            SetUpPlayersPanels();
            TestPlayerPanel();
        }

        /// <summary>
        /// Sets up player panels according to the number of players in the PlayerManager.
        /// </summary>
        private void SetUpPlayersPanels()
        {
            int panelsLeft = playersPanels.Length;
            foreach (var player in playerManager.GetPlayers())
            {
                for (int i = 0; i < panelsLeft; i++)
                {
                    if (player.GetPlayerPanel() == null)
                    {
                        i = i + panelsLeft - 1;
                        player.SetPlayerPanel(playersPanels[i]);
                        break;
                    }
                }
                panelsLeft--;
            }
        }

        /// <summary>
        /// Tests the player panel setup by logging the player panel names and the current player's panel and color.
        /// </summary>
        private void TestPlayerPanel()
        {
            Debug.Log(playerManager.GetCurrentPlayer().GetPlayerPanel().name + " " + playerManager.GetCurrentPlayer().GetPlayerColor().name);
            foreach (var player in playerManager.GetPlayers())
            {
                Debug.Log(player.GetPlayerPanel().name);
            }
        }
    }
}
