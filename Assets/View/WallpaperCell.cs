using PexelsDotNetSDK.Models;
using UnityEngine;
using UnityEngine.UI;


public class WallpaperCell:MonoBehaviour
{
    public Button collection;
    public Button download;
    public Button like;
    public RawImage img;
    private Photo data;
    public void Init(Texture tex,Photo photo)
    {
        data = photo;
        img.texture = tex;
        GetComponent<Button>().onClick.AddListener(()=>{Debug.Log("打开详情");});
        GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200.0f / photo.width * photo.height);
    }
    
}
