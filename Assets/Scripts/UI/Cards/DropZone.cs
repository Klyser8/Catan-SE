using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This script enables a drop zone for draggable objects like development cards within the game's user interface.
/// </summary>
public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject newParent;

    /// <summary>
    /// Called when the pointer enters the drop zone.
    /// </summary>
    /// <param name="eventData">Data related to the pointer event.</param>
    public void OnPointerEnter(PointerEventData eventData) {
        // Debug.Log("OnPointerEnter");
    }

    /// <summary>
    /// Called when the pointer exits the drop zone.
    /// </summary>
    /// <param name="eventData">Data related to the pointer event.</param>
    public void OnPointerExit(PointerEventData eventData) {
        // Debug.Log("OnPointerExit");
    }

    /// <summary>
    /// Called when an object is dropped into the drop zone.
    /// </summary>
    /// <param name="eventData">Data related to the drop event.</param>
    public void OnDrop(PointerEventData eventData) {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        DragDropDevCard d = eventData.pointerDrag.GetComponent<DragDropDevCard>();
        if(d != null) {
            d.initialParent = newParent.transform;
        }
    }
}

