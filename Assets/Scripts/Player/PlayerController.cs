using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Material _playerColor;
        private int _victoryPoints;
        private ResourceHandler _resourceHandler;
        private ArrayList _buildings = new();
        private ArrayList _roads = new();

        void Start()
        {
            _resourceHandler = gameObject.AddComponent<ResourceHandler>();
        }

        public void Initialize(Material playerColor)
        {
            _playerColor = playerColor;
        }

        /**
         * Adds victory points to the player
         */
        public void AddVictoryPoints(int amount)
        {
            _victoryPoints += amount;
        }
        
        /**
         * Subtracts victory points from the player
         */
        public void SubtractVictoryPoints(int amount)
        {
            _victoryPoints -= amount;
        }
        
        /**
         * Returns the amount of victory points the player has
         */
        public int GetVictoryPoints()
        {
            return _victoryPoints;
        }
        
        /**
         * Returns the player's color
         */
        public Material GetPlayerColor()
        {
            return _playerColor;
        }

        /**
         * Adds a settlement to the player's list of buildings.
         */
        public void AddSettlement(GameObject settlement)
        {
            _buildings.Add(settlement);
        }
        
        /**
         * Returns the player's list of buildings.
         */
        public ArrayList GetBuildings()
        {
            return _buildings;
        }
        
        /**
         * Adds a road to the player's list of roads.
         */
        public void AddRoad(GameObject road)
        {
            _roads.Add(road);
        }
        
        /**
         * Returns the player's list of roads.
         */
        public ArrayList GetRoads()
        {
            return _roads;
        }
        
        /**
         * Returns the player's resource handler.
         */
        public ResourceHandler GetResourceHandler()
        {
            return _resourceHandler;
        }
    }
}
