using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;
using Unity.XR.CoreUtils;

public class ARManager : MonoBehaviour
{
    public static ARManager ins;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI helpText;
    [SerializeField] private TextMeshProUGUI audioClipDurationText;
    [SerializeField] private Button scanButton;


    [Header("AR")]
    [SerializeField] private ARTrackedImageManager imageManager;

    [Header("Target Manager")]
    [SerializeField] public TargetManager targetManager;

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

    public void Reload_BaseVariables()
    {
        //Set TARGET MANAGER
        targetManager = GameObject.Find("3D_Enviroment(Clone)").GetComponent<TargetManager>();

        //Set SMALL VIDEO PLAYER
        SmallVideo _aux_smallVideo = GameObject.Find("3D_Enviroment(Clone)")
            .transform.GetChild(1).gameObject
            .transform.GetChild(0).gameObject
            .GetComponent<SmallVideo>();

        smallVideoPlayer.Add(_aux_smallVideo);

        //Set BIG VIDEO PLAYERs
        BigVideoPlayer _aux_bigVideo_I = GameObject.Find("3D_Enviroment(Clone)")
            .transform.GetChild(1).gameObject
            .transform.GetChild(1).gameObject
            .GetComponent<BigVideoPlayer>();
        bigVideoPlayer.Add(_aux_bigVideo_I);

        BigVideoPlayer _aux_bigVideo_II = GameObject.Find("3D_Enviroment(Clone)")
            .transform.GetChild(1).gameObject
            .transform.GetChild(3).gameObject
            .GetComponent<BigVideoPlayer>();
        bigVideoPlayer.Add(_aux_bigVideo_II);

        //Set ARROW
        arrow = GameObject.Find("3D_Enviroment(Clone)")
            .transform.GetChild(1).gameObject
            .transform.GetChild(2).gameObject
            .GetComponent<Arrow>();
    }

    public void Set_Enabled_ImageManager(bool status)
    {
        //imageManager.enabled = status;
        Debug.Log("Image Manager Set Enabled : " + status);
    }

    public void Set_Text_HelpText(string s)
    {
        string message = s;
        //helpText.text = message;
    }

    public void Set_Text_AudioClipDuration(string s)
    {
        string message = s;
        //audioClipDurationText.text = message;
    }

    public void Set_ScanButton(bool s)
    {
        bool status = s;
        //scanButton.interactable = status;
    }

    public void Next()
    {
        _counter ++;

        if(_counter == 1)
        {
            //Set_Text_HelpText("Activa el primer Big video player");
            Deactivate_All_SmallVideo();
            Deactivate_All_VideoPlayer();
            Active_videoPlayer(0);
        }

        //on clip ended de bigVideoPlayer,llamar a Next()
        if(_counter == 2)
        {
            //Set_Text_HelpText("Activa arrow y despues de 5 seg, el segundo Big video player");
            Deactivate_All_VideoPlayer();
            Set_Enable_Arrow(true);

            float _timer = 5.0f;    //Timer para que active el proximo Big Video Player
            Invoke(nameof(Next), _timer);
        }
        
        if(_counter == 3)
        {
            //Set_Text_HelpText("Activa el segundo video");
            Deactivate_All_VideoPlayer();
            Set_Enable_Arrow(false);
            Active_videoPlayer(1);
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