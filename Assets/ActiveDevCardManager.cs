using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDevCardManager : MonoBehaviour
{
    int index = 1;
    public Transform hand;
    public void PlayCard() {
        // Check if the index is valid
        
        
            // Get the child object at the specified index
            Transform childTransform = this.transform.GetChild(index);
            childTransform.SetParent(null);
            Destroy(childTransform.gameObject);
        
    }

    public void ReturnCard() {
        Transform childTransform = this.transform.GetChild(index);
        childTransform.SetParent(hand);
    }
}
