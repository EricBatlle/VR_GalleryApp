using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;
using VRStandardAssets.Utils;

public class GalleryBarButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private Scrollbar scrollbar;
    [Space]
    [SerializeField] private float objectsCanFit = 4;
    [SerializeField] private int elementsToScroll = 4;
    [SerializeField] private float scrollSpeed = 0.01f;

    private float totalElements;
    private float hiddenElements;
    private float unitaryDistance;

    public enum ScrollDirection
    {
        Forward,
        Backward
    }
    float getScrollDirection(ScrollDirection sd)
    {
        if (sd == ScrollDirection.Forward)
        { return 1; }
        else if (sd == ScrollDirection.Backward)
        { return -1; }
        return 1;
    }
    bool isScrollDirectionForward(ScrollDirection sd)
    {
        if (sd == ScrollDirection.Forward)
        { return true; }
        else if (sd == ScrollDirection.Backward)
        { return false; }
        return true;
    }
    public ScrollDirection scrollDirection;

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
        MoveScrollbar();
    }
    //GearVR
    public void HandleClick()
    {
        //Debug.Log("Show click state");
        MoveScrollbar();
    }

    private void MoveScrollbar()
    {

        totalElements = GameObject.FindWithTag("Grid").transform.childCount;
        hiddenElements = totalElements - objectsCanFit;
        unitaryDistance = 1 / hiddenElements;
        
        StartCoroutine("SmoothMovement");
    }

    IEnumerator SmoothMovement()
    {
        float scrollbarEndDistance = scrollbar.value + (unitaryDistance * getScrollDirection(scrollDirection)) * elementsToScroll;

        if (isScrollDirectionForward(scrollDirection))
        {
            while ((float)Math.Round(scrollbar.value,2) < Mathf.Clamp(scrollbarEndDistance, 0, 1))
            {            
                scrollbar.value += scrollSpeed;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while ((float)Math.Round(scrollbar.value, 2) > Mathf.Clamp(scrollbarEndDistance, 0, 1))
            {                
                scrollbar.value -= scrollSpeed;
                yield return new WaitForEndOfFrame();
            }
        }
    }

    void IPointerEnterHandler.OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
    {
        //print("OnPointerEnter");
    }

    void IPointerExitHandler.OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
    {
    }

    //Handle the Over event
    private void HandleOver()
    {
        //Debug.Log("Show over state");
    }

   
    //Handle the Out event
    private void HandleOut()
    {
        //Debug.Log("Show out state");
    }

    
    //Handle the DoubleClick event
    private void HandleDoubleClick()
    {
        //Debug.Log("Show double click");
    }

}
