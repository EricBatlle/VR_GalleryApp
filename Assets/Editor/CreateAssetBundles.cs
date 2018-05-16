using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundles : MonoBehaviour {

    [MenuItem("Eric/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        //BuildPipeline.BuildAssetBundles("Assets/AssetBundles");
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
