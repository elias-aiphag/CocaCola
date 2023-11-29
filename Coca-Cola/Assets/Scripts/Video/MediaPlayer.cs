using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class MediaPlayer : MonoBehaviour
{
    [SerializeField] private double _videoLenght; //Convert to float
    [SerializeField] private VideoPlayer videoPlayer;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        Get_videoLenght();
    }

    public void Get_videoLenght()
    {
        double d = videoPlayer.length;
        _videoLenght = d;
        Debug.Log(this.name + "videoClip duration is : " + d);
    }

    private void Deactive()
    {
        this.gameObject.SetActive(false);
    }
}
