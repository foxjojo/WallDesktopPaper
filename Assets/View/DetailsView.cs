using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsView : MonoBehaviour
{
    public RawImage image;

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
        sourceType.onValueChanged.AddListener(SourceTypeOnChanged);
      
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
