using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoTitle : MonoBehaviour
{
    [SerializeField] private string title;
    [SerializeField] private TextMeshProUGUI text_title;

    void Start()
    {
        SetName(title);
    }

    private void SetName(string _s)
    {
        string message = _s;
        text_title.text = message;
    }
}
