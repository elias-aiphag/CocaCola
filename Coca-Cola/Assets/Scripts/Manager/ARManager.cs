using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;
using Unity.XR.CoreUtils;

public class ARManager : MonoBehaviour
{
    public static ARManager ins;

    [Header("VideoObjects")]
    [SerializeField] private AudioPlayer audioPlayer;
    [SerializeField] private List<MediaPlayer> bigVideoPlayer;

    [Header("Arrow")]
    [SerializeField] public Arrow arrow;

    [Header("Counter")]
    [SerializeField] private int _counter = 0;

    [Header("Canvas Static")]
    [SerializeField] private Transform _staticUI;

    void Awake()
    {
        //Get_staticUI();
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

            //Set_parent_videoPlayer(0);
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

            //Set_parent_videoPlayer(2);
            Set_Status_videoPlayer(2, true);
            Set_Status_videoPlayer(0, false);
        }

        if(_counter == 5)
        {
            Debug.Log("time to : video 2");

            Set_Status_videoPlayer(3, true);
            Set_Status_videoPlayer(2, false);
            Set_Enable_Arrow(false);
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
        bigVideoPlayer[i].gameObject.SetActive(b);
    }

    public void Set_parent_videoPlayer(int i)
    {
        bigVideoPlayer[i].transform.SetParent(_staticUI);
    }

    private void Deactivate_All_VideoPlayer()
    {
        foreach(MediaPlayer e in bigVideoPlayer)
        {
            e.gameObject.SetActive(false);
        }
    }

    public void Set_active_smallVideoPlayer(bool b)
    {
        bool _status = b;
        audioPlayer.gameObject.SetActive(_status);
    }

    private void Get_staticUI()
    {
        GameObject _ui = GameObject.Find("Canvas_Static_UI");
        _staticUI = _ui.gameObject.transform;
    }
}