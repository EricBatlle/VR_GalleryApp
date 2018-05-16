﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VRStandardAssets.Utils;

public class EnableFilterUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 

    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private GameObject UI;

    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
    }

    //Handle the Over event
    private void HandleOver()
    {
        UI.SetActive(true);
    }


    //Handle the Out event
    private void HandleOut()
    {
        UI.SetActive(false);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
