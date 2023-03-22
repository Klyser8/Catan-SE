using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
    
        public int victoryPoints = 0;

        // Start is called before the first frame update
        void Start()
        {
            gameObject.AddComponent<ResourceHandler>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
