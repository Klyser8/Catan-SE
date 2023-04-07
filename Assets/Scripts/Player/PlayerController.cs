using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
    
        private int _victoryPoints = 0;
        private ResourceHandler _resourceHandler;

        // Start is called before the first frame update
        void Start()
        {
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
        
        public ResourceHandler GetResourceHandler()
        {
            return _resourceHandler;
        }
    }
}
