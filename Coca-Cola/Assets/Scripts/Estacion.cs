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
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioClip[] audioSound;

    void Start()
    {
        ReloadTitle(title);
    }

    private void ReloadTitle(string s)
    {
        string _text = s;
        mainText.text = _text;
    }

    public void PlayClip(int number)
    {
        AudioClip clip = audioSound[number];
        audioManager.PlayAudioClip(clip);
    }

    private void LoadClipSound(AudioClip aClip)
    {
        audioManager.PlayAudioClip(aClip);
    }
}
