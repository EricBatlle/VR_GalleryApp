using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundImageManager : MonoBehaviour
{

    [SerializeField] private MediaItem mediaItem = null;
    [SerializeField] private Shader flippingNormals;

    [SerializeField]private RawImage m_raw = null;

    public Texture texture = null;
    public string imgUrl;

    public void Start()
    {

        if (mediaItem != null) //So it's a backgroundImageController for thumbnails
        {
            imgUrl = mediaItem.urlThumbnail;
            if(m_raw == null)
                m_raw = GetComponent<RawImage>();

            changeImg2d(imgUrl);
        }
    }

    public void setTexture()
    {
        if(texture != null)
            m_raw.texture = texture;
    }

    //Change "2D" thumbnail background images
    public void changeImg2d(string imgUrl)
    {
        StartCoroutine(changeImg2dRoutine(imgUrl));
    }
    IEnumerator changeImg2dRoutine(string imgUrl)
    {
        //WWW www = new WWW(imgUrl);
        //yield return www;
        //GetComponent<Image>().sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));

        WWW www = new WWW(imgUrl);
        yield return www;

        texture = www.texture;
    }

    //Change "2D" thumbnail background images
    public void changeImg(string imgUrl)
    {
        StartCoroutine(changeImgRoutine(imgUrl));
    }
    IEnumerator changeImgRoutine(string imgUrl)
    {
        WWW www = new WWW(imgUrl);
        yield return www;

        texture = www.texture;
        m_raw.texture = texture;
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
        m_raw.texture = www.texture;
    }

}
