using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableIfDaydream : MonoBehaviour {

    [SerializeField] private GameObject VRPlatformController;

    private void Update()
    {
        if (VRPlatformController == null)
        {
            VRPlatformController = GameObject.FindGameObjectWithTag("VRPlatformController");
            if (VRPlatformController.GetComponent<VRPlatformSelector>().isDaydream)
            {
                this.gameObject.SetActive(false);
            }
        }
        
    }

}
