using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberData : MonoBehaviour
{
    [SerializeField] private int number;
    
    public int GetNumber()
    {
        return number;
    }
    
}