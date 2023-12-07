using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioPlayer : MonoBehaviour
{
    [Header("Media Lenght")]
    [SerializeField] private double _lenghtDouble;
    [SerializeField] public float _lenghtFloat;
    [SerializeField] public float _time;

    [Header("Media Lenght")]
    [SerializeField] private bool _ended = false;

    [Header("Media Lenght")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Estacion estacion;

    [Header("Timers")]
    [SerializeField] private float timeTo_Animation1;
    [SerializeField] private float timeTo_Video1;
    [SerializeField] private float timeTo_Arrow;
    [SerializeField] private float timeTo_Animation2;
    [SerializeField] private float timeTo_Video2;
    [SerializeField] private float timeTo_Animation3;

    void Start()
    {
        Init();
    }

    void LateUpdate()
    {
        Refresh();
    }

    private void Refresh()
    {
        if(!_ended)
        {
            Get_videoTime();
            Set_estacionTime();
        }
    }

    private void Init()
    {
        Get_videoLenght();
        Set_estacionAmplitude();

        Invoke(nameof(Call_Next), timeTo_Animation1);
        Invoke(nameof(Call_Next),timeTo_Video1);
        Invoke(nameof(Call_Next),timeTo_Arrow);
        Invoke(nameof(Call_Next),timeTo_Animation2);
        Invoke(nameof(Call_Next),timeTo_Video2);
        Invoke(nameof(Call_Next),timeTo_Animation3);

        Invoke(nameof(Clip_Ended),_lenghtFloat);
    }

    public void Get_videoLenght()
    {
        double d = videoPlayer.length;
        _lenghtDouble = d;
        _lenghtFloat = Double_To_Float(_lenghtDouble);
    }

    public void Get_videoTime()
    {
        double d = videoPlayer.time;
        float f = Double_To_Float(d);
        _time = f;
    }

    public void Set_estacionTime()
    {
        estacion.SliderUpdate(_time);
    }

    public void Set_estacionAmplitude()
    {
        estacion.SliderMaxAmp(_lenghtFloat);
        estacion.TextAudioLenght(_lenghtFloat);
    }

    private void Clip_Ended()
    {
        bool b = true;
        _ended = b;

        Call_Next();
    }

    private void Call_Next()
    {
        ARManager.ins.Next();
    }

    public float Double_To_Float(double _d)
    {
        float _f;
        _f = (float)_d;
        return _f;
    }
}
