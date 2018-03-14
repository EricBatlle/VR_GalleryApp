using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRPlatformSelector : MonoBehaviour {
    [SerializeField] private GameObject DaydreamSet;
    [SerializeField] private GameObject GearVrSet;

    [Space]
    [SerializeField] private Camera DaydreamCamera;
    [SerializeField] private Camera GearVrCamera;

    [SerializeField] private bool isDebuging = true;
    [SerializeField] public bool isGearVR = false;
    [SerializeField] public bool isDaydream = false;

    private Camera cameraActive;
    public Camera getCameraActive { get { return cameraActive; } }

    void disableSettingsFor(GameObject set)
    {
        set.SetActive(false);        
        if (set == GearVrSet)
        {
            GearVrCamera.tag = "Untagged";
            cameraActive = DaydreamCamera;
            isDaydream = true;
        }
        else if (set == DaydreamSet)
        {
            DaydreamCamera.tag = "Untagged";
            cameraActive = GearVrCamera;
            isGearVR = true;
        }
    }

    // Use this for initialization
    void Start () {
        
        DontDestroyOnLoad(transform.gameObject);
        
        if (isDebuging)
        {
            if (isDaydream)
            {
                disableSettingsFor(GearVrSet);
            }
            else
            {
                disableSettingsFor(DaydreamSet);
            }
        }
        else
        {
            if (XRSettings.loadedDeviceName == "daydream")
            {
                disableSettingsFor(GearVrSet);
            }
            else
            {
                disableSettingsFor(DaydreamSet);
            }
        }
    }    

}
