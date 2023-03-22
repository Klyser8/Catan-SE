using UnityEngine;

namespace Action
{
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