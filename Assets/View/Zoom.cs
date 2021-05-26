using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Zoom : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    private float preTime = 0;
    private Vector3 dragOrginPos;
    private Vector3 imgDragOrginPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragOrginPos = Input.mousePosition;
        imgDragOrginPos = transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // transform.localPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position =imgDragOrginPos+ Input.mousePosition - dragOrginPos ;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.clickTime);
      
        if ( eventData.clickTime - preTime > 0.3f)
        {
            preTime =  eventData.clickTime;
            return;
        }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.localScale += Vector3.one;
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (transform.localScale.x > 1)
            {
                transform.localScale -= Vector3.one;
            }
            else
            {
                transform.localPosition = Vector3.one;
            }
        }
    }
}