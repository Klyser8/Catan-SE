using UnityEngine;

namespace Player
{
    /**
     * Script to handle a player's resources.
     */
    public class ResourceHandler : MonoBehaviour
    {
        public int Wood { get; set; }
        public int Wheat { get; set; }
        public int Clay { get; set; }
        public int Ore { get; set; }
        public int Sheep { get; set; }
    
        public void AddResources(int woodAmount, int wheatAmount, int clayAmount, int oreAmount, int sheepAmount)
        {
            Wood += woodAmount;
            Wheat += wheatAmount;
            Clay += clayAmount;
            Ore += oreAmount;
            Sheep += sheepAmount;
            return;
        }
    
        public void SubtractResources(int woodAmount, int wheatAmount, int clayAmount, int oreAmount, int sheepAmount)
        {
            Wood -= woodAmount;
            Wheat -= wheatAmount;
            Clay -= clayAmount;
            Ore -= oreAmount;
            Sheep -= sheepAmount;
            return;
            // if (woodAmount > 0) giveToBank.GiveToBank("Wood(Clone)");
            // if (wheatAmount > 0) giveToBank.GiveToBank("Wheat(Clone)");
            // if (clayAmount > 0) giveToBank.GiveToBank("Brick(Clone)");
            // if (oreAmount > 0) giveToBank.GiveToBank("Ore(Clone)");
            // if (sheepAmount > 0) giveToBank.GiveToBank("Sheep(Clone)");
        }

        public bool HasResources(int woodAmount, int wheatAmount, int clayAmount, int oreAmount, int sheepAmount)
        {
            return 
                Wood >= woodAmount && 
                Wheat >= wheatAmount && 
                Clay >= clayAmount && 
                Ore >= oreAmount && 
                Sheep >= sheepAmount;
        }
    }
}
