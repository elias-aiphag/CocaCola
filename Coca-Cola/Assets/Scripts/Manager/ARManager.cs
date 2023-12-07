using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;
using Unity.XR.CoreUtils;

public class ARManager : MonoBehaviour
{
    public static ARManager ins;

    [SerializeField] private AudioPlayer audioPlayer;
    [SerializeField] private List<MediaPlayer> videoPlayer;

    [Header("Arrow")]
    [SerializeField] public Arrow arrow;

    [Header("Counter")]
    [SerializeField] private int _counter = 0;

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        if(ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void Next()
    {
        _counter ++;

        if(_counter == 1)
        {
            Debug.Log("time to : animacion 1");

            Set_Status_videoPlayer(0, true);
        }

        if(_counter == 2)
        {
            Debug.Log("time to : video 1");

            Set_Status_videoPlayer(0, false);
            Set_Status_videoPlayer(1, true);
        }
        
        if(_counter == 3)
        {
            Debug.Log("time to : arrow");

            Set_Enable_Arrow(true);
        }

        if(_counter == 4)
        {
            Debug.Log("time to : animacion 2");

            Set_Status_videoPlayer(2, true);
            Set_Status_videoPlayer(1, false);
        }

        if(_counter == 5)
        {
            Debug.Log("time to : video 2");

            Set_Status_videoPlayer(3, true);
            Set_Status_videoPlayer(2, false);
            Set_Enable_Arrow(false);
        }

        if(_counter == 6)
        {
            Debug.Log("time to : animacion 3");

            Set_Status_videoPlayer(4, true);
            Set_Status_videoPlayer(3, false);
        }

        if(_counter == 7)
        {
            Debug.Log("Clear All");

            Set_Status_videoPlayer(4, false);
        }

        else { return; }
    }

    private void Set_Enable_Arrow(bool _b)
    {
        bool status  = _b;
        arrow.gameObject.SetActive(status);
    }

    public void Set_Status_videoPlayer(int i, bool b)
    {
        videoPlayer[i].gameObject.SetActive(b);
    }

    private void Deactivate_All_VideoPlayer()
    {
        foreach(MediaPlayer e in videoPlayer)
        {
            e.gameObject.SetActive(false);
        }
    }

    public void Set_active_smallVideoPlayer(bool b)
    {
        bool _status = b;
        audioPlayer.gameObject.SetActive(_status);
    }
}