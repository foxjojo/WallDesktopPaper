using System.Collections;
using System.Collections.Generic;
using System.IO;
using DesktopWallpaper;
using PexelsDotNetSDK.Api;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject temp;
    private static IDesktopWallpaper dw;

    private PexelsClient pexelsClient;

    // Start is called before the first frame update
    void Start()
    {
        pexelsClient = new PexelsClient("563492ad6f91700001000001abee145ae98747cd8160adfdbcde89a3");
        GetNaturePhotos();
    }

    async private void GetNaturePhotos()
    {
        var result = await pexelsClient.SearchPhotosAsync("nature");
        foreach (var photo in result.photos)
        {
        
            StartCoroutine(SaveImg(photo.source.original, "C:/Users/Gkoala/Desktop/" + photo.photographerId+".jpg"));
        }
    }

    private void SetWallpaper(string path)
    {
        if (dw == null)
            dw = (new DesktopWallpaperClass()) as IDesktopWallpaper;
        dw.SetWallpaper(dw.GetMonitorDevicePathAt(0), path);
    }

    private IEnumerator SaveImg(string url, string savePath)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
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
                File.WriteAllBytes(savePath, uwr.downloadHandler.data);
                CreateWallImg(texture, savePath);
            }
        }
    }

    private void CreateWallImg(Texture texture, string path)
    {
        var t = Instantiate(temp);
        t.transform.SetParent(temp.transform.parent);
        t.GetComponent<RawImage>().texture = texture;
        t.name = path;
        t.GetComponent<Button>().onClick.AddListener(delegate { SetWallpaper(t.name); });
        t.SetActive(true);
    }
}