using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    /// <summary>
    /// The `PlayerController` class represents a player in the game.
    /// It manages the player's color, victory points, resources, buildings, and roads.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        private Material _playerColor;
        private int _victoryPoints;
        private ResourceHandler _resourceHandler;
        private ArrayList _buildings = new();
        private ArrayList _roads = new();
        private GameObject _playerPanel;
        private int panelIndex;

        void Start()
        {
            _resourceHandler = gameObject.AddComponent<ResourceHandler>();
        }

        /// <summary>
        /// Initializes the player's color, which is used to color the player's buildings and roads.
        /// The color should be chosen based on the player's index in the player list.
        /// </summary>
        /// <param name="playerColor">The player's color material.</param>
        public void Initialize(Material playerColor)
        {
            _playerColor = playerColor;
        }

        /// <summary>
        /// Adds victory points to the player.
        /// </summary>
        /// <param name="amount">The amount of victory points to add.</param>
        public void AddVictoryPoints(int amount)
        {
            _victoryPoints += amount;
        }
        
        /// <summary>
        /// Subtracts victory points from the player.
        /// </summary>
        /// <param name="amount">The amount of victory points to subtract.</param>
        public void SubtractVictoryPoints(int amount)
        {
            _victoryPoints -= amount;
        }
        
        /// <summary>
        /// Returns the amount of victory points the player has.
        /// </summary>
        /// <returns>The player's victory points.</returns>
        public int GetVictoryPoints()
        {
            return _victoryPoints;
        }
        
        /// <summary>
        /// Returns the player's color material.
        /// </summary>
        /// <returns>The player's color material.</returns>
        public Material GetPlayerColor()
        {
            return _playerColor;
        }

        /// <summary>
        /// Adds a settlement to the player's list of buildings.
        /// </summary>
        /// <param name="settlement">The settlement game object to add.</param>
        public void AddSettlement(GameObject settlement)
        {
            _buildings.Add(settlement);
        }
        
        /// <summary>
        /// Returns the player's list of buildings.
        /// </summary>
        /// <returns>The player's list of buildings.</returns>
        public ArrayList GetBuildings()
        {
            return _buildings;
        }
        
        /// <summary>
        /// Adds a road to the player's list of roads.
        /// </summary>
        /// <param name="road">The road game object to add.</param>
        public void AddRoad(GameObject road)
        {
            _roads.Add(road);
        }
        
        /// <summary>
        /// Returns the player's list of roads.
        /// </summary>
        /// <returns>The player's list of roads.</returns>
        public ArrayList GetRoads()
        {
            return _roads;
        }
        
        /// <summary>
        /// Returns the player's resource handler.
        /// </summary>
        /// <returns>The player's resource handler.</returns>
        public ResourceHandler GetResourceHandler()
        {
            return _resourceHandler;
        }

        public void SetPlayerPanel(GameObject newPlayerPanel) {
            _playerPanel = newPlayerPanel;
        }

        public GameObject GetPlayerPanel()
        {
            return _playerPanel;
        }
    }
}
