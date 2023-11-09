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
    [SerializeField] private List<SmallVideo> smallVideoPlayer;
    [SerializeField] private List<BigVideoPlayer> bigVideoPlayer;

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
            Debug.Log("When 2 seconds passed...");
            Active_videoPlayer(0);
        }

        if(_counter == 2)
        {
            Debug.Log("When first audio ended...");
            Deactivate_All_SmallVideo();
            Active_videoPlayer(1);
        }
        
        if(_counter == 3)
        {
            Debug.Log("When second video ended...");
            Deactivate_All_VideoPlayer();
            Set_Enable_Arrow(true);
            Invoke(nameof(Next),4.0f);
        }

        if(_counter == 4)
        {
            Debug.Log("When 4seg pased...");
            Active_videoPlayer(2);
            Set_Enable_Arrow(false);
        }

        if(_counter == 5)
        {
            Debug.Log("All finished...");
            Deactivate_All_VideoPlayer();
            Deactivate_All_SmallVideo();
        }
        
        else
        {
            return;
        }
        
    }

    private void Set_Enable_Arrow(bool _b)
    {
        bool status  = _b;
        arrow.gameObject.SetActive(status);
    }

    public void Active_videoPlayer(int i)
    {
        Deactivate_All_VideoPlayer();
        bigVideoPlayer[i].gameObject.SetActive(true);
    }

    private void Deactivate_All_VideoPlayer()
    {
        foreach(BigVideoPlayer e in bigVideoPlayer)
        {
            e.gameObject.SetActive(false);
        }
    }

    public void Set_active_smallVideoPlayer(int i)
    {
        Deactivate_All_SmallVideo();
        smallVideoPlayer[i].gameObject.SetActive(true);
    }

    private void Deactivate_All_SmallVideo()
    {
        foreach(SmallVideo sm in smallVideoPlayer)
        {
            sm.gameObject.SetActive(false);
        }
    }
}