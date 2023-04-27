using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using Player;

public class TestResourcesUI : MonoBehaviour
{
    public TMP_InputField resource;
    public TMP_InputField num; // Reference to your TMP Input Field
    public GetResources test;
    private PlayerManager _playerManager;

    private void Start() {
        _playerManager = FindObjectOfType<PlayerManager>();
    }
    // Call this function whenever you want to read the text from the input field
    public void ReadTextFromInputField()
    {
        string resourceIndex = resource.text;
        string numberOfResources = num.text;
       
        
        int result1 = int.Parse(resourceIndex);
        int result2 = int.Parse(numberOfResources);
        Debug.Log("Converted using Parse: " + result2);

        test.TakeResources(result2, result1);

        var player = _playerManager.GetCurrentPlayer();
        switch (result1) {
            case 0:
                player.GetResourceHandler().AddResources(0, 0, result2, 0, 0);
                break;
            case 1:
                player.GetResourceHandler().AddResources(0, 0, 0, result2, 0);
                break;
            case 2:
                player.GetResourceHandler().AddResources(0, 0, 0, 0, result2);
                break;
            case 3:
                player.GetResourceHandler().AddResources(0, result2, 0, 0, 0);
                break;
            case 4:
                player.GetResourceHandler().AddResources(result2, 0, 0, 0, 0);
                break;
            default:
                Debug.Log("Invalid resource index");
                break;
        }
    }
}

