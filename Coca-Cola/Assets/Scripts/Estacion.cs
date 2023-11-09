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

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI audioLenght_text;
    [SerializeField] private Slider sliderAudioLenght;
    
    void Start()
    {
        ReloadTitle(title);

        //Invoke(nameof(NextEvent), 4.0f);    //time to next event, synced to "24.000 botellas"
        //Invoke(nameof(NextEvent), _clipDuration);
    }

    private void ReloadTitle(string s)
    {
        string _text = s;
        mainText.text = _text;
    }

    public void SliderUpdate(float f)
    {
        float _f = f;
        sliderAudioLenght.value = _f;
        //Debug.Log("slider audio lenght : " + _f);
    }

    public void SliderMaxAmp(float f)
    {
        float _f = f;
        sliderAudioLenght.maxValue = _f;
        //Debug.Log("slider max amplitude : " + f);
    }

    public void TextAudioLenght(float f)
    {
        string _s = f.ToString();
        audioLenght_text.text = _s;
        //Debug.Log("audio lenght text : " + _s);
    }

    public void ClipEnded()
    {
        Debug.Log(title + " has ended, can continue");
        //sARManager.ins.Next();
        //Deactive();
    }

    public void NextEvent()
    {
        ARManager.ins.Next();
    }

    private void Deactive()
    {
        this.gameObject.SetActive(false);
    }

}