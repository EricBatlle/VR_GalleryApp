using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class ToggleComponent : MonoBehaviour {
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    public Toggle Toggle;
    public Action onChange;

    private void Start()
    {
        Toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, and output the state
        Toggle.onValueChanged.AddListener(
            delegate {
                ToggleValueChanged(Toggle);
            }
        );
    }

    //Output the new state of the Toggle into Text when the user uses the Toggle
    void ToggleValueChanged(Toggle change)
    {
        if(onChange != null)
            onChange();
    }

    private void OnEnable()
    {
        m_InteractiveItem.OnClick += HandleClick;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnClick -= HandleClick;
    }

    //Handle the Click event
    private void HandleClick()
    {
        //ToDo: NO ENTRA EN EL EVENTO CLICK EN VR
        print("click");
        Toggle.isOn = !Toggle.isOn;
    }
}
