using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
    public static string TempSavePath
    {
        get;
        private set; }

    private string DefaultTempSavePath()
    {
        if (string.IsNullOrEmpty(TempSavePath))
        {
            TempSavePath = Application.persistentDataPath;
        }

        return TempSavePath;
    }
}