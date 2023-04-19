using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
    
        private GameManager _gameManager;
        private int _victoryPoints = 0;
        private ResourceHandler _resourceHandler;
        private ArrayList _buildings = new();
        private ArrayList _roads = new();

        void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _resourceHandler = gameObject.AddComponent<ResourceHandler>();
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
