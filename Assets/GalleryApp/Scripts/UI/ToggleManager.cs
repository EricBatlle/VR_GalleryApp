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
    public List<ToggleComponent> toggles;

    [SerializeField] public bool video2dState;
    [SerializeField] public bool video360State;
    [SerializeField] private bool img2dState;
    [SerializeField] private bool img360State;

    private void OnEnable()
    {
        video2d.onChange += checkFilter;
        video360.onChange += checkFilter;
        img2d.onChange += checkFilter;
        img360.onChange += checkFilter;

        toggles = new List<ToggleComponent>();
        toggles.Add(video2d);
        toggles.Add(video360);
        toggles.Add(img2d);
        toggles.Add(img360);
    }

    private void OnDisable()
    {
        video2d.onChange -= checkFilter;
        video360.onChange -= checkFilter;
        img2d.onChange -= checkFilter;
        img360.onChange -= checkFilter;
    }

    private void checkFilter()
    {
        //Check the toggles state
        video2dState = video2d.Toggle.isOn;
        video360State = video360.Toggle.isOn;
        img2dState = img2d.Toggle.isOn;
        img360State = img360.Toggle.isOn;
        //Find on gallery the video 2D and empty an auxiliar list
        List<GameObject> auxGallery = new List<GameObject>();

        foreach (GameObject go in GalleryManager.instance.gallery)
        {
            if (video2dState && go.GetComponent<MediaItem>().contentType.Equals("video2d"))
            {
                go.SetActive(true);
            }                
            else if (video360State && go.GetComponent<MediaItem>().contentType.Equals("video360"))
            {
                go.SetActive(true);
            }
            else if (img2dState && go.GetComponent<MediaItem>().contentType.Equals("img2d"))
            {
                go.SetActive(true);
            }
            else if (img360State && go.GetComponent<MediaItem>().contentType.Equals("img360"))
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
        }
    }
}
