using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class GalleryManager : MonoBehaviour
{
    [SerializeField] private GameObject m_VRPlatformControllerPrefab;
    [SerializeField] private GameObject interactiveMediaItemPrefab;
    [SerializeField] private RectTransform prefabRectTransform;
    [SerializeField] private GameObject itemsParent;
    private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
    private VRPlatformSelector m_VRPlatformSelector;    

    //Instantiable objects
    private GameObject interactiveMediaItemCopy;
    private GameObject VRPlatformController;

    public string urlContent;   

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
            VRPlatformController = Instantiate(m_VRPlatformControllerPrefab, new Vector3(0,0.5f,4.5f), new Quaternion());
            m_VRPlatformSelector = VRPlatformController.GetComponent<VRPlatformSelector>();            
        }
    }

    private void OnLevelWasLoaded()
    {
        //if camerafade is lost when swapping between scenes
        //m_CameraFade = FindObjectOfType<VRCameraFade>();
    }

    public void CreateGallery(JsonInfo[] objects){
        foreach (JsonInfo jsonMediaObject in objects)
        {
            interactiveMediaItemCopy = Instantiate(interactiveMediaItemPrefab, itemsParent.transform.position, new Quaternion());
            interactiveMediaItemCopy.GetComponent<MediaItem>().setValues(jsonMediaObject);
            interactiveMediaItemCopy.transform.parent = itemsParent.transform;
            interactiveMediaItemCopy.GetComponent<RectTransform>().localScale = prefabRectTransform.localScale;
        }
    }

    public IEnumerator GoToScene(string m_SceneToLoad,string mediaUrlContent)
    {
        m_CameraFade = m_VRPlatformSelector.getCameraActive.GetComponent<VRCameraFade>();
        urlContent = mediaUrlContent;
        //Just in case nothing is attached            
        if (m_CameraFade != null)
        {
            // If the camera is already fading, ignore.
            if (m_CameraFade.IsFading)
                yield break;

            // Wait for the camera to fade out.
            yield return StartCoroutine(m_CameraFade.BeginFadeOut(true));

            print("sceneToLoad"+m_SceneToLoad);
            if (!String.IsNullOrEmpty(m_SceneToLoad))
            {
                // Load the level.
                SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
            }
        }
    }

}
