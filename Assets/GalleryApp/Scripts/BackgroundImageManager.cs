using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundImageManager : MonoBehaviour
{

    [SerializeField] private MediaItem mediaItem = null;
    [SerializeField] private Shader flippingNormals;

    public string imgUrl;

    public void Start()
    {

        if (mediaItem != null) //So it's a backgroundImageController for thumbnails
        {
            imgUrl = mediaItem.urlThumbnail;
            changeImg2d(imgUrl);
        }
    }

    //Change "2D" background images
    public void changeImg2d(string imgUrl)
    {
        StartCoroutine(changeImg2dRoutine(imgUrl));
    }
    IEnumerator changeImg2dRoutine(string imgUrl)
    {
        WWW www = new WWW(imgUrl);
        yield return www;
        GetComponent<Image>().sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }

    //Change 3D background images
    public void changeImg360(string imgUrl)
    {
        StartCoroutine(changeImg360Routine(imgUrl));
    }
    IEnumerator changeImg360Routine(string imgUrl)
    {
        yield return 0;
        WWW www = new WWW(imgUrl);
        yield return www;
        GetComponent<Renderer>().material.mainTexture = www.texture;
        GetComponent<Renderer>().material.shader = flippingNormals;
    }

}
