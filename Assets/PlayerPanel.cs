using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Player
{
    public class PlayerPanel : MonoBehaviour
    {
        public GameObject[] playersPanels;
        private PlayerManager playerManager;

        private void Start() {
            playerManager = FindObjectOfType<PlayerManager>();
            SetUpPlayersPanels();
            TestPlayerPanel();
        } 

        private void SetUpPlayersPanels() {
            int panelsLeft = playersPanels.Length;
            foreach(var player in playerManager.GetPlayers())
            {
                for(int i = 0; i < panelsLeft; i++) 
                {
                    if(player.GetPlayerPanel() == null) {
                        i = i + panelsLeft - 1;
                        player.SetPlayerPanel(playersPanels[i]);
                        break;
                    }
                }
                panelsLeft--;
            }
        }

        private void TestPlayerPanel() {
            Debug.Log(playerManager.GetCurrentPlayer().GetPlayerPanel().name + " " + playerManager.GetCurrentPlayer().GetPlayerColor().name);
            foreach(var player in playerManager.GetPlayers()) {
                Debug.Log(player.GetPlayerPanel().name);
            }
        }
    }
}
