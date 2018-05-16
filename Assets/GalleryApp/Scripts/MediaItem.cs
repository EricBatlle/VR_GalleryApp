using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class MediaItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private GalleryManager m_GalleryManager;
    [SerializeField] private GameObject marker;

    [Header("Media Attributes")]
    [SerializeField] private string m_SceneToLoad;  // The name of the scene to load.
    [SerializeField] public string title;
    [SerializeField] public string urlThumbnail;
    [SerializeField] public string urlContent;
    [SerializeField] public string contentType;     //"img360","img2d","video360","video2d"

    public void Start()
    {
        m_GalleryManager = FindObjectOfType<GalleryManager>();
    }

    public void setValues(JsonInfo jsonMediaObject)
    {
        this.title = jsonMediaObject.title;
        this.urlThumbnail = jsonMediaObject.urlThumbnail;
        this.urlContent = jsonMediaObject.urlContent;
        this.contentType = jsonMediaObject.contentType;
        this.m_SceneToLoad = this.contentType;
    }

    public void setValues(GameObject mediaItemObject)
    {
        MediaItem mediaItem = mediaItemObject.GetComponent<MediaItem>();

        if (mediaItem != null)
        {
            this.title = mediaItem.title;
            this.urlThumbnail = mediaItem.urlThumbnail;
            this.urlContent = mediaItem.urlContent;
            this.contentType = mediaItem.contentType;
            this.m_SceneToLoad = this.contentType;
        }        
    }

    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnClick += HandleClick;
        m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnClick -= HandleClick;
        m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
    }

    //Handle the Click event
    //Daydream
    void IPointerClickHandler.OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        StartCoroutine(m_GalleryManager.GoToScene(contentType, urlContent));
    }

    //Handle the Over event
    private void HandleOver()
    {
        marker.SetActive(true);
    }


    //Handle the Out event
    private void HandleOut()
    {
        marker.SetActive(false);
    }


    //Handle the Click event
    private void HandleClick()
    {
        //Debug.Log("Show click state");
        StartCoroutine(m_GalleryManager.GoToScene(contentType,urlContent));
    }

    //Handle the DoubleClick event
    private void HandleDoubleClick()
    {
        //Debug.Log("Show double click");
    }

    void IPointerEnterHandler.OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
    {
        //print("OnPointerEnter");
    }

    void IPointerExitHandler.OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
    {
    }
}
