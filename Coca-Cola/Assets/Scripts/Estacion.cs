using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Estacion : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private String title;

    [Header("Audio")]
    [SerializeField] private AudioClip audioSound;
    [SerializeField] private float _clipDuration = 2.0f;
    [SerializeField] private bool _ended;

    [Header("TargetManager")]
    [SerializeField] private TargetManager targetManager;

    void Start()
    {
        ReloadTitle(title);
        PlayClip();
    }

    private void ReloadTitle(string s)
    {
        string _text = s;
        mainText.text = _text;
    }

    public void PlayClip()
    {
        AudioClip clip = audioSound;
        AudioManager.ins.PlayAudioClip(clip);
        AudioManager.ins.ChangeVolume(10);

        _clipDuration = AudioManager.ins.Get_ClipLenght(clip);
        string s = _clipDuration.ToString();
        ARManager.ins.Set_Text_AudioClipDuration(s);

        Invoke("ClipEnded",_clipDuration);
    }

    public void ClipEnded()
    {
        Debug.Log(title + " has ended, can continue");
        _ended = true;
        //ARManager.ins.Next();
        targetManager.Set_Enable_target(true);

        //Deactive();
    }

    private void Deactive()
    {
        this.gameObject.SetActive(false);
    }
}
