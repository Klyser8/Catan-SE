using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject newParent;

    public void OnPointerEnter(PointerEventData eventData) {
        // Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData) {
        // Debug.Log("OnPointerExit");
    }

    public void OnDrop(PointerEventData eventData) {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        DragDropDevCard d = eventData.pointerDrag.GetComponent<DragDropDevCard>();
        if(d != null) {
            d.initialParent = newParent.transform;

        }
    }
}
