using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class GalleryController : MonoBehaviour
{

    [SerializeField] private VRInput m_Input;
    [SerializeField] private GalleryBarButton m_ButtonNext;
    [SerializeField] private GalleryBarButton m_ButtonBack;
    
    private void OnEnable()
    {
        if (m_Input != null)
        {
            m_Input.OnSwipe += HandleSwipe;
        }        
    }

    private void OnDisable()
    {
        if (m_Input != null)
        {
            m_Input.OnSwipe -= HandleSwipe;
        }
    }    

    private void HandleSwipe(VRInput.SwipeDirection swipeDirection)
    {
        switch (swipeDirection)
        {
            case VRInput.SwipeDirection.NONE:
                break;
            case VRInput.SwipeDirection.UP:
                break;
            case VRInput.SwipeDirection.DOWN:
                break;
            case VRInput.SwipeDirection.LEFT:
                m_ButtonBack.HandleClick();
                break;
            case VRInput.SwipeDirection.RIGHT:
                m_ButtonNext.HandleClick();
                break;
        }
    }
    
}
