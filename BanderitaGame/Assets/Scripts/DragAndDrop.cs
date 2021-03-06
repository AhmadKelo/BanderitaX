using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour,  IDragHandler
{
    //Between MonoBegaviour and IDragHandler
    // IPointerDownHandler, IBeginDragHandler, IEndragHandler,

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     Debug.Log("OnBeginDrag");
    // }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     Debug.Log("OndEndDrag");
    // }

    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     Debug.Log("OnPointerDown");
    // }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     collision.collider.transform.SetParent(transform);
    // }

    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     collision.collider.transform.SetParent(null);
    // }
}
