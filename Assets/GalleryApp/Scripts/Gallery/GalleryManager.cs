using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class GalleryManager : MonoBehaviour
{
    public static GalleryManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    [SerializeField] private GameObject m_VRPlatformControllerPrefab;
    [SerializeField] private GameObject interactiveMediaItemPrefab;
    [SerializeField] private RectTransform prefabRectTransform;
    [SerializeField] private GameObject itemsParent = null;
    private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
    private VRPlatformSelector m_VRPlatformSelector;

    private bool galleryCreated;
    //Instantiable objects
    private GameObject interactiveMediaItemCopy;
    private GameObject VRPlatformController;

    public List<GameObject> gallery = new List<GameObject>();

    public string urlContent;
    
    private void OnEnable()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }

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

    private void Update()
    {
        if (galleryCreated)
        {
            if (everyTextureLoaded())
            {
                setThumbnails();
                galleryCreated = false;
            }
        }
    }

    private void OnLevelWasLoaded()
    {
        //if camerafade is lost when swapping between scenes
        //m_CameraFade = FindObjectOfType<VRCameraFade>();
    }

    public void CreateGallery(JsonInfo[] objects){
        
        itemsParent = GameObject.FindGameObjectWithTag("Grid");
        //itemsParent = transform.Find("/GalleryCanvas/List/Grid").gameObject;
        gallery.Clear();
        galleryCreated = false;
        foreach (JsonInfo jsonMediaObject in objects)
        {
            interactiveMediaItemCopy = Instantiate(interactiveMediaItemPrefab, itemsParent.transform.position, new Quaternion());
            interactiveMediaItemCopy.GetComponent<MediaItem>().setValues(jsonMediaObject);
            interactiveMediaItemCopy.transform.parent = itemsParent.transform;
            interactiveMediaItemCopy.GetComponent<RectTransform>().localScale = prefabRectTransform.localScale;

            gallery.Add(interactiveMediaItemCopy);
        }
        galleryCreated = true;
    }

    public void setThumbnails()
    {
        foreach (GameObject item in gallery)
        {
            item.GetComponent<MediaItem>().backgroundManager.setTexture();            
        }
    }

    public bool everyTextureLoaded()
    {
        bool allOk = true;
        foreach (GameObject item in gallery)
        {
            if (item.GetComponent<MediaItem>().backgroundManager.texture == null)
                allOk = false;
        }
        return allOk;
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
