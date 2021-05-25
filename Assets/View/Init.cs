using System;
using System.Collections;
using System.Collections.Generic;
using DesktopWallpaper.Logic;
using UnityEngine;

public class Init : MonoBehaviour
{
    private void OnEnable()
    {
        NetworkOps.Init();
    }
}
