using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyIfGear : MonoBehaviour {
    [SerializeField] private GameObject VRPlatformController;    

    public void Awake()
    {
        if (VRPlatformController != null)
        {
            VRPlatformController = GameObject.FindGameObjectWithTag("VRPlatformController");
            if (VRPlatformController.GetComponent<VRPlatformSelector>().isGearVR)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            enabled = false;
        }
    }
}
