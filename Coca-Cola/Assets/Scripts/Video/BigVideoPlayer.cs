using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class BigVideoPlayer : MonoBehaviour
{
    [SerializeField] private double _videoLenght; //Convert to float
    [SerializeField] private bool _ended;
    [SerializeField] private bool _callNext;
    [SerializeField] private VideoPlayer videoPlayer;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        Get_videoLenght();
        Invoke(nameof(VideoClip_Ended),(float)_videoLenght);
    }

    public void Get_videoLenght()
    {
        double d = videoPlayer.length;
        _videoLenght = d;
        Debug.Log(this.name + "videoClip duration is : " + d);
    }

    private void VideoClip_Ended()
    {
        bool b = true;
        _ended = b;
        videoPlayer.Stop();

        if(_callNext) {ARManager.ins.Next();}

        //Deactive();
    }

    private void Deactive()
    {
        this.gameObject.SetActive(false);
    }
}
