using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Estacion : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private String title;

    [Header("Audio")]
    [SerializeField] private AudioClip audioSound;
    [SerializeField] private float _clipDuration;
    [SerializeField] private bool _ended;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI audioLenght_text;
    [SerializeField] private Slider sliderAudioLenght;
    
    void Start()
    {
        ReloadTitle(title);
        PlayClip();
    }

    void LateUpdate()
    {
        ClipTime();
    }

    private void ReloadTitle(string s)
    {
        string _text = s;
        mainText.text = _text;
    }

    public void ClipTime()
    {
        float _t = AudioManager.ins.Get_Clip_Time();
        sliderAudioLenght.value = _t;
    }

    public void PlayClip()
    {
        //CLIPS
        AudioClip clip = audioSound;
        AudioManager.ins.PlayAudioClip(clip);
        AudioManager.ins.ChangeVolume(50);

        //Set ClipLength
        _clipDuration = AudioManager.ins.Get_ClipLenght(clip);
        ClipLenght(_clipDuration);

        float _timerToKeyword = 2.0f;   //Timer hasta que el audio diga "24.000 botellas"
        Invoke(nameof(Active_SmallVideoPlayer), _timerToKeyword);

        //Ended
        Invoke(nameof(ClipEnded), _clipDuration);
    }

    public void ClipEnded()
    {
        Debug.Log(title + " has ended, can continue");
        _ended = true;
        ARManager.ins.Next();
        //Deactive();
    }

    public void Active_SmallVideoPlayer()
    {
        ARManager.ins.targetManager.Set_Enable_target(true);
        ARManager.ins.Set_active_smallVideoPlayer(0);
    }

    private void Deactive()
    {
        this.gameObject.SetActive(false);
    }

    private void ClipLenght(float f)
    {
        //Set slider
        sliderAudioLenght.maxValue = f;

        //Set as String
        string message = f.ToString();
        audioLenght_text.text = message;
    }
}