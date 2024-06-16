﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class CreateAssetBundles 
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string dir = "AssetBundles";
        if(Directory.Exists(dir)==false)
        {
            Directory.CreateDirectory(dir);
        }

        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        //BuildPipeline.BuildAssetBundle(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
