using UnityEngine;

namespace Player
{
    /// <summary>
    /// The `ResourceHandler` class handles a player's resources.
    /// It provides methods to add, subtract, and check resource amounts.
    /// </summary>
    public class ResourceHandler : MonoBehaviour
    {
        public int Wood { get; set; }
        public int Wheat { get; set; }
        public int Clay { get; set; }
        public int Ore { get; set; }
        public int Sheep { get; set; }
    
        /// <summary>
        /// Adds resources to the player's resource amounts.
        /// </summary>
        /// <param name="woodAmount">The amount of wood to add.</param>
        /// <param name="wheatAmount">The amount of wheat to add.</param>
        /// <param name="clayAmount">The amount of clay to add.</param>
        /// <param name="oreAmount">The amount of ore to add.</param>
        /// <param name="sheepAmount">The amount of sheep to add.</param>
        public void AddResources(int woodAmount, int wheatAmount, int clayAmount, int oreAmount, int sheepAmount)
        {
            Wood += woodAmount;
            Wheat += wheatAmount;
            Clay += clayAmount;
            Ore += oreAmount;
            Sheep += sheepAmount;
        }
    
        /// <summary>
        /// Subtracts resources from the player's resource amounts.
        /// </summary>
        /// <param name="woodAmount">The amount of wood to subtract.</param>
        /// <param name="wheatAmount">The amount of wheat to subtract.</param>
        /// <param name="clayAmount">The amount of clay to subtract.</param>
        /// <param name="oreAmount">The amount of ore to subtract.</param>
        /// <param name="sheepAmount">The amount of sheep to subtract.</param>
        public void SubtractResources(int woodAmount, int wheatAmount, int clayAmount, int oreAmount, int sheepAmount)
        {
            Wood -= woodAmount;
            Wheat -= wheatAmount;
            Clay -= clayAmount;
            Ore -= oreAmount;
            Sheep -= sheepAmount;
        }

        /// <summary>
        /// Checks if the player has enough resources.
        /// </summary>
        /// <param name="woodAmount">The required amount of wood.</param>
        /// <param name="wheatAmount">The required amount of wheat.</param>
        /// <param name="clayAmount">The required amount of clay.</param>
        /// <param name="oreAmount">The required amount of ore.</param>
        /// <param name="sheepAmount">The required amount of sheep.</param>
        /// <returns>True if the player has enough resources; false otherwise.</returns>
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
