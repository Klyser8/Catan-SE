using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : MonoBehaviour
{
    
    public int Wood { get; set; } = 0;
    public int Wheat { get; set; } = 0;
    public int Clay { get; set; } = 0;
    public int Ore { get; set; } = 0;
    public int Sheep { get; set; } = 0;
    
    public void AddResources(int woodAmount, int wheatAmount, int clayAmount, int oreAmount, int sheepAmount)
    {
        Wood += woodAmount;
        Wheat += wheatAmount;
        Clay += clayAmount;
        Ore += oreAmount;
        Sheep += sheepAmount;
    }
    
    public void SubtractResources(int woodAmount, int wheatAmount, int clayAmount, int oreAmount, int sheepAmount)
    {
        Wood -= woodAmount;
        Wheat -= wheatAmount;
        Clay -= clayAmount;
        Ore -= oreAmount;
        Sheep -= sheepAmount;
    }

    public bool HasResources(int woodAmount, int wheatAmount, int clayAmount, int oreAmount, int sheepAmount)
    {
        return Wood >= woodAmount && Wheat >= wheatAmount && Clay >= clayAmount && Ore >= oreAmount && Sheep >= sheepAmount;
    }

}
