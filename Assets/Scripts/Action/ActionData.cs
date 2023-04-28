using UnityEngine;

namespace Action
{
    /// <summary>
    /// The `ActionData` class represents the cost of a specific action in the game.
    /// It stores the resource costs required to perform the action.
    /// </summary>
    [CreateAssetMenu(fileName = "ActionData", menuName = "Action Data")]
    public class ActionData : ScriptableObject
    {
        public int woodCost;
        public int wheatCost;
        public int clayCost;
        public int oreCost;
        public int sheepCost;
    }
}