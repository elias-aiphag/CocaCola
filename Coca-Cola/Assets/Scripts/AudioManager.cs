using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager ins;

    [SerializeField] public AudioSource audioSource;

    private void Awake()
    {
        if(ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void ChangeVolume(int amount)
    {
        int volume = Mathf.Clamp(amount, 0 , 100);
        float volumeNormalized = volume / 100.0f;
        audioSource.volume = volumeNormalized;
    }

    public float Get_ClipLenght(AudioClip clip)
    {
        return clip.length;
    }

    public void Get_AudioClipFinished()
    {
        Debug.Log("Has ended");
    }

    public float Get_Clip_Time()
    {
        float _t = audioSource.time;
        return _t;
    }
}
