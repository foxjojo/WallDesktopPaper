using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesktopWallpaper.Logic;
using PexelsDotNetSDK.Models;
using UnityEngine.Networking;

public class MainView : MonoBehaviour
{
    /// <summary>
    /// 当前精选页
    /// </summary>
    private int nowCuratedPage = 1;

    public GameObject tempCell;

    public List<GameObject> cellPool;

    // Start is called before the first frame update
    void Start()
    {
        GetCuratedPhotos();
    }

    /// <summary>
    /// 得到精选照片
    /// </summary>
    async private void GetCuratedPhotos()
    {
        var result = await NetworkOps.pexelsClient.CuratedPhotosAsync(nowCuratedPage);

        foreach (var photo in result.photos)
        {
            StartCoroutine(SaveImg(photo));
        }
    }

    private IEnumerator SaveImg(Photo photo)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(photo.source.large))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                var texture = DownloadHandlerTexture.GetContent(uwr);

                CreateWallpaperCell(texture, photo);
            }
        }
    }

    private void CreateWallpaperCell(Texture tex, Photo photo)
    {
        var t = Instantiate(tempCell, tempCell.transform.parent, true);
        t.GetComponent<WallpaperCell>().Init(tex, photo);
        AdaptiveVertical.Instance.AddChild(t.GetComponent<RectTransform>());
        t.SetActive(true);
    }
}