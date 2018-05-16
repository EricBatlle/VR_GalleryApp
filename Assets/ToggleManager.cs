using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour {

    [SerializeField] public ToggleComponent video2d;
    [SerializeField] public ToggleComponent video360;
    [SerializeField] private ToggleComponent img2d;
    [SerializeField] private ToggleComponent img360;
    private Action blabla;

    private void OnEnable()
    {
        video2d.onChange += checkFilter;
    }

    private void OnDisable()
    {
        video2d.onChange -= checkFilter;
    }

    private void checkFilter()
    {
        //Supoused that the check is for the video 2D

        //Find on gallery the video 2D and empty an auxiliar list
        List<GameObject> auxGallery = new List<GameObject>();

        foreach (GameObject go in GalleryManager.instance.gallery)
        {
            if(go.GetComponent<MediaItem>().contentType.Equals("video360"))
            {
                auxGallery.Add(go);
                print(go.GetComponent<MediaItem>().title);
            }
        }

        //Swap the current list for the new aux list
        GalleryManager.instance.SwapGallery(auxGallery);
    }
}
