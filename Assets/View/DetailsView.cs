using System;
using System.Collections;
using System.Collections.Generic;
using PexelsDotNetSDK.Models;
using UnityEngine;
using UnityEngine.UI;

public class DetailsView : MonoBehaviour
{
    public RawImage image;
    public Button close;
    public Text likeCount;

    public GameObject info;
    public Text infoDate;
    public Text infoCameraLens;
    public Text infoSize;
    public Text infoResolution;
    public Text infoCam;
    public Text infoSoftware;
    public Text infoShotDate;
    public Text infoAspectRatio;

    public RawImage icon;
    public Text author;
    public Button collection;
    public Dropdown sourceType;
    public Button download;
    public Button applyWallpaper;


    // Start is called before the first frame update
    void Start()
    {
        close.onClick.AddListener(delegate { gameObject.SetActive(false); });
        sourceType.onValueChanged.AddListener(SourceTypeOnChanged);
    }

    public void Init(Texture tex, Photo data)
    {
        gameObject.SetActive(true);
        infoSize.text = "大小（款*高）：" + data.width + "*" + data.height;
     
        
        SetImageSize(tex, data);
    }

    private void SetImageSize(Texture tex, Photo data)
    {
        image.texture = tex;
        var backSize = GetComponent<RectTransform>().rect;
        float x = 0;
        float y = 0;
        if (data.width > data.height)
        {
            y = (float)data.height / (float)data.width * backSize.width;
            x = backSize.width;
        }
        else
        {
            x = (float)data.width / (float)data.height * backSize.height;
            y = backSize.height;
        }

        image.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
    }

    private void SourceTypeOnChanged(int value)
    {
        Config.ImageQuality t = (Config.ImageQuality) value;
        switch (t)
        {
            case Config.ImageQuality.original:
                break;
            case Config.ImageQuality.large2x:
                break;
            case Config.ImageQuality.large:
                break;
            case Config.ImageQuality.medium:
                break;
            case Config.ImageQuality.small:
                break;
            case Config.ImageQuality.portrait:
                break;
            case Config.ImageQuality.landscape:
                break;
            case Config.ImageQuality.tiny:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }

    void Update()
    {
    }
}