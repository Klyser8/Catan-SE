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

        // Start is called before the first frame update
        void Start()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _resourceHandler = gameObject.AddComponent<ResourceHandler>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        public void AddVictoryPoints(int amount)
        {
            _victoryPoints += amount;
        }
        
        public void SubtractVictoryPoints(int amount)
        {
            _victoryPoints -= amount;
        }
        
        public int GetVictoryPoints()
        {
            return _victoryPoints;
        }
        
        public void AddSettlement(GameObject settlement)
        {
            _buildings.Add(settlement);
        }
        
        public ArrayList GetBuildings()
        {
            return _buildings;
        }
        
        public ResourceHandler GetResourceHandler()
        {
            return _resourceHandler;
        }
    }
}
