using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdaptiveVertical : MonoBehaviour
{
    public static AdaptiveVertical Instance;
    private RectTransform _rectTransform;
    private List<RectTransform> childs;
    public Vector2 offset;
    public int horizontalCount = 1;

    private void OnEnable()
    {
        _rectTransform = GetComponent<RectTransform>();
        Instance = this;
        childs = new List<RectTransform>();
    }

    public void AddChild(RectTransform rectTransform)
    {
        childs.Add(rectTransform);
        SetChildPos(rectTransform, childs.Count);
    }

    private void SetChildPos(RectTransform rectTransform, int pos)
    {
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(0, 1);
        int relativePosition = pos % horizontalCount;

        float posX = offset.x;
        if (relativePosition == 0)
        {
            relativePosition = horizontalCount;
        }

        for (int i = 1; i < relativePosition; i++)
        {
            posX += childs[pos - relativePosition].rect.width + offset.x;
        }

        posX += offset.x;
        posX += rectTransform.rect.width / 2.0f;

        float posY = -offset.y;
        Debug.Log("posY" + posY);
        for (int i = 0; i >= 0; i++)
        {
            int t = (i + 1) * horizontalCount;
            if (t >= pos || pos < horizontalCount)
                break;
 
            if (relativePosition == 0)
            {
                relativePosition = horizontalCount;
            }  

            posY -= (childs[i * horizontalCount + relativePosition - 1].rect.height + offset.y);
          
        }

         posY -= offset.y;
        posY -= rectTransform.rect.height / 2.0f;

        rectTransform.anchoredPosition = new Vector2(posX, posY);
        CalculateCanvasXSize(posX + rectTransform.rect.width / 2.0f);

        CalculateCanvasYSize(posY - rectTransform.rect.height /2.0f);
    }

    private void CalculateCanvasXSize(float width)
    {
        if (_rectTransform.rect.width < width)
        {
            _rectTransform.sizeDelta = new Vector2(width + offset.x, _rectTransform.sizeDelta.y);
        }
    }

    private void CalculateCanvasYSize(float height)
    {
        height = Math.Abs(height);
        if (_rectTransform.rect.height < height)
        {
            _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, height + offset.y);
        }
    }
}