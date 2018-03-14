using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonManager : MonoBehaviour {
    [SerializeField] private GalleryManager m_galleryManager;
    [SerializeField] private string jsonUrl = "http://test.local/simple.json";

    
    //Server JSON - ARRAY/OBJECT
    void Start()
    {
        string url = jsonUrl;
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));        
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
            JsonInfo[] objects = JsonHelper.getJsonArray<JsonInfo>(www.text);
            //Debug.Log(objects[0].title);
            m_galleryManager.CreateGallery(objects);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    //void Start()
    //{
    //Local JSON extraction - OBJECT
    //print(Path.Combine("JSON", "simple"));
    //TextAsset jsonObj = Resources.Load(Path.Combine("JSON", "simple")) as TextAsset;
    //JsonInfo glyphMap = JsonUtility.FromJson<JsonInfo>(jsonObj.text);
    //print(glyphMap.name);

    //Local JSON extraction - ARRAY 
    //TextAsset jsonObj = Resources.Load(Path.Combine("JSON", "simple")) as TextAsset;
    //JsonInfo[] objects = JsonHelper.getJsonArray<JsonInfo>(jsonObj.text);
    //print(objects[1].name);    
    //}

}
