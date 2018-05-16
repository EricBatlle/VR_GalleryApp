using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BundleLoader : MonoBehaviour {

    [SerializeField] private string url;
    [SerializeField] private string urlPrefabName;

    private void Start()
    {
        StartCoroutine("Load");
    }

    IEnumerator Load()
    {

        //url = "http://localhost/assetBundle/cuberotate"; //Bundle name HERE
        using (UnityWebRequest uwr = UnityWebRequest.GetAssetBundle(url))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);

                //IF CODE
                //TextAsset[] txts = bundle.LoadAllAssets<TextAsset>();
                //foreach (TextAsset txt in txts)
                //    System.Reflection.Assembly.Load(txt.bytes);

                GameObject Mya = bundle.LoadAsset(urlPrefabName) as GameObject; //Prefab Bundle name HERE
                Instantiate(Mya);
            }
        }
    }
}
