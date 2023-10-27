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
    //[SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip audioSound;
    [SerializeField] private float _clipDuration;

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
    }
}
