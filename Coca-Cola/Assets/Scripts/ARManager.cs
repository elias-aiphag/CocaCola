using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;

public class ARManager : MonoBehaviour
{
    public static ARManager ins;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI helpText;
    [SerializeField] private TextMeshProUGUI audioClipDurationText;
    [SerializeField] private Button scanButton;

    [Header("Arrow")]
    [SerializeField] private GameObject arrow;

    [Header("AR")]
    [SerializeField] private ARTrackedImageManager imageManager;

    [Header("Target Manager")]
    [SerializeField] public TargetManager targetManager;

    [Header("VideoObjects")]
    [SerializeField] private List<SmallVideo> smallVideoPlayer;
    [SerializeField] private List<VideoPlayer> bigVideoPlayer;

    [Header("Counter")]
    [SerializeField] private int _counter = 0;

    void Awake()
    {
        Init();

        Set_Enabled_ImageManager(false);
        Set_Text_HelpText("Precione el boton 'scan'");
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

    public void Set_Enabled_ImageManager(bool status)
    {
        imageManager.enabled = status;
        Debug.Log("Image Manager Set Enabled : " + status);
    }

    public void Set_Text_HelpText(string s)
    {
        string message = s;
        helpText.text = message;
    }

    public void Set_Text_AudioClipDuration(string s)
    {
        string message = s;
        audioClipDurationText.text = message;
    }

    public void Set_ScanButton(bool s)
    {
        bool status = s;
        scanButton.interactable = status;
    }

    public void Next()
    {
        _counter ++;

        if(_counter == 1)
        {
            Set_Text_HelpText("Activa el primer video");
            Set_deactivate_All_SmallVideo();
            Deactivate_All_VideoPlayer();
            Active_videoPlayer(0);

            Set_Enable_Arrow(true);
        }

        //on clip ended de bigVideoPlayer,llamar a Next()
        if(_counter == 2)
        {
            Set_Text_HelpText("Activa el segundo video");
        }
        
        if(_counter == 3)
        {
            Set_Text_HelpText("Activa el segundo video");
            Deactivate_All_VideoPlayer();
            Active_videoPlayer(1);
            Set_Enable_Arrow(false);
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
        foreach(VideoPlayer e in bigVideoPlayer)
        {
            e.gameObject.SetActive(false);
        }
    }

    public void Set_active_smallVideoPlayer(int i)
    {
        Set_deactivate_All_SmallVideo();
        smallVideoPlayer[i].gameObject.SetActive(true);
    }

    private void Set_deactivate_All_SmallVideo()
    {
        foreach(SmallVideo sm in smallVideoPlayer)
        {
            sm.gameObject.SetActive(false);
        }
    }
}