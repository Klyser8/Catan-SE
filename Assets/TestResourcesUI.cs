using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class TestResourcesUI : MonoBehaviour
{
    public TMP_InputField resource;
    public TMP_InputField num; // Reference to your TMP Input Field
    public GetResources test;

    // Call this function whenever you want to read the text from the input field
    public void ReadTextFromInputField()
    {
        string resourceIndex = resource.text;
        string numberOfResources = num.text;
       
        
            int result1 = int.Parse(resourceIndex);
            int result2 = int.Parse(numberOfResources);
            Debug.Log("Converted using Parse: " + result2);
        

        test.TakeResources(result2, result1);
    }
}

