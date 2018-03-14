using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;
using VRStandardAssets.Utils;

public class exampleInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private Text text;

    public bool isInteractive = true;


    void Update()
    {
        if (GvrControllerInput.AppButtonDown)
        {
            print("RECOGIDO!");
        }
    }  

    void IPointerEnterHandler.OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (isInteractive)
        {
            print("pointerEnter");
        }
    }

    void IPointerExitHandler.OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (isInteractive)
        {
            print("pointerExit");
        }
    }

    void IPointerClickHandler.OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (isInteractive)
        {
            print("pointerClick");
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

    //Handle the Over event
    public void HandleOver()
    {
        Debug.Log("Show over state");
        text.text = XRSettings.loadedDeviceName;
    }


    //Handle the Out event
    private void HandleOut()
    {
        //Debug.Log("Show out state");
    }


    //Handle the Click event
    private void HandleClick()
    {
        //Debug.Log("Show click state");
        //StartCoroutine(m_GalleryManager.GoToScene(contentType, urlContent));
    }

    //Handle the DoubleClick event
    private void HandleDoubleClick()
    {
        //Debug.Log("Show double click");
    }
}
