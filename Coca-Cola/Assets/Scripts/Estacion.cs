using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("TargetManager")]
    [SerializeField] private TargetManager targetManager;

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
        AudioManager.ins.ChangeVolume(10);

        //Set ClipLength
        _clipDuration = AudioManager.ins.Get_ClipLenght(clip);
        //string s = _clipDuration.ToString();
        ClipLenght(_clipDuration);

        //Ended
        Invoke("ClipEnded",_clipDuration);
    }

    public void ClipEnded()
    {
        Debug.Log(title + " has ended, can continue");
        _ended = true;
        targetManager.Set_Enable_target(true);
        //ARManager.ins.Next();
        //Deactive();
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
        ARManager.ins.Set_Text_AudioClipDuration(message);
        audioLenght_text.text = message;
    }
}
