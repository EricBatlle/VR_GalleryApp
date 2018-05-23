using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VRStandardAssets.Utils;

public class DisableFilterUI : MonoBehaviour
{

    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private GameObject UI;
    [SerializeField] private ToggleManager m_toggleM;

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
    }

    //Handle the Out event
    private void HandleOut()
    {
        bool onToggleOver = false;
        //if is not selecting any Toggle
        foreach (ToggleComponent toggle in m_toggleM.toggles)
        {
            if (toggle.onOver)
            {
                onToggleOver = true;
            }
        }
        if (onToggleOver == false)
        {
            UI.SetActive(false);
        }
    }
    
}
