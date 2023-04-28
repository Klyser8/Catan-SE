using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This script allows a development card to be dragged and dropped within the game's user interface.
/// </summary>
public class DragDropDevCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform initialParent = null;

    /// <summary>
    /// Called when the user starts dragging the development card.
    /// </summary>
    /// <param name="eventData">Data related to the drag event.</param>
    public void OnBeginDrag(PointerEventData eventData) {
       Debug.Log ("OnBeginDrag");
       initialParent = this.transform.parent;
       this.transform.SetParent(this.transform.parent.parent);

       GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    /// <summary>
    /// Called when the user is dragging the development card.
    /// </summary>
    /// <param name="eventData">Data related to the drag event.</param>
    public void OnDrag(PointerEventData eventData) {
       this.transform.position = eventData.position;
    }

    /// <summary>
    /// Called when the user stops dragging the development card.
    /// </summary>
    /// <param name="eventData">Data related to the drag event.</param>
    public void OnEndDrag(PointerEventData eventData) {
       Debug.Log ("OnEndDrag");
       this.transform.SetParent(initialParent);
       GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
