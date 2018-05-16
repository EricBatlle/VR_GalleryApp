using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleComponent : MonoBehaviour {

    private Toggle m_Toggle;
    public Action onChange;

    private void Start()
    {
        m_Toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, and output the state
        m_Toggle.onValueChanged.AddListener(
            delegate {
                ToggleValueChanged(m_Toggle);
            }
        );
    }

    //Output the new state of the Toggle into Text when the user uses the Toggle
    void ToggleValueChanged(Toggle change)
    {
        if(onChange != null)
            onChange();
    }
}
