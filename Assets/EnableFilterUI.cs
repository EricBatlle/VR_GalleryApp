using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VRStandardAssets.Utils;

public class EnableFilterUI : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] bool startEnable = false;
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private GameObject UI;
    [SerializeField] private ToggleManager m_toggleM;

    private BoxCollider m_collider;
    
    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;

        m_collider = this.GetComponent<BoxCollider>();
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
    }
    
    private void Start()
    {
        UI.SetActive(startEnable);
        //m_collider.enabled = !startEnable;
    }

    private void Update()
    {
        
    }

    //Handle the Over event
    private void HandleOver()
    {
        UI.SetActive(true);
    }

    //Handle the Out event
    private void HandleOut()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UI.SetActive(true);
    }

    
}
