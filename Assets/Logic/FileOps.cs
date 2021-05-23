using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace DesktopWallpaper.Logic
{
    public class FileOps
    {
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
            // var t = Instantiate(temp);
            // t.transform.SetParent(temp.transform.parent);
            // t.GetComponent<RawImage>().texture = texture;
            // t.name = path;
            // t.GetComponent<Button>().onClick.AddListener(delegate { SetWallpaper(t.name); });
            // t.SetActive(true);
        }
    }
}