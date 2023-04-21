using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public Material[] playerMaterials;
    
    public void SetColor(GameObject settlement, int playerIndex)
    {
        // Find the "Castle" child object
        Transform settelmentChild = settlement.transform.Find("CatanHouseNew");
        Transform settelmentGrandChild = settelmentChild.transform.Find("roof");
        if (settelmentGrandChild != null)
        {
            // Assign the material based on the player's index
            Renderer settelmentRenderer = settelmentGrandChild.GetComponent<Renderer>();
            if (settelmentRenderer != null && playerIndex >= 0 && playerIndex < playerMaterials.Length)
            {
                Material[] materials = settelmentRenderer.materials;
                materials[1] = playerMaterials[playerIndex]; // Assuming Element 1 is the one to be replaced
                settelmentRenderer.materials = materials;
            }
            else
            {
                Debug.LogError("Invalid player index or missing Renderer component");
            }
        }
        else
        {
            Debug.LogError("Settelment child object not found");
        }
    }
}

