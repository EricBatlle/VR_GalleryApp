using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DisplayManager : MonoBehaviour
{
    private GalleryManager m_GalleryManager;

    // Use this for initialization
    void Start ()
    {
        m_GalleryManager = FindObjectOfType<GalleryManager>();
        setContent();
    }

    public void setContent()
    {
        string sceneType = SceneManager.GetActiveScene().name;
        switch (sceneType)
        {
            case "video360":
            case "video2d":
                setVideo();
                break;
            case "img360":
                setImg360();
                break;            
            case "img2d":
                setImg2d();
                break;
            default:
                break;
        }
    }

    public void setVideo()
    {
        GetComponent<VideoPlayer>().url = m_GalleryManager.urlContent;
    }
    public void setImg360()
    {        
        GetComponent<BackgroundImageManager>().changeImg360(m_GalleryManager.urlContent);
    }
    public void setImg2d()
    {
        GetComponent<BackgroundImageManager>().changeImg(m_GalleryManager.urlContent);
    }
}
