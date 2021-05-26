using System;
using PexelsDotNetSDK.Models;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class WallpaperCell:MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject menu;
    public Button collection;
    public Button download;
    public Button like;
    public RawImage img;
    private Photo data;
    public void Init(Texture tex,Photo photo,Action action)
    {
        data = photo;
        img.texture = tex;
        GetComponent<Button>().onClick.AddListener(()=>{Debug.Log("打开详情");action.Invoke();});
        GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200.0f / photo.width * photo.height);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        menu.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       menu.SetActive(false);
    }
}
