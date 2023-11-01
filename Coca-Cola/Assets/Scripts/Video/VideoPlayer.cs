using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayer : MonoBehaviour
{
    public void Set_Enable_videoPlayer(bool _b)
    {
        bool status = _b;
        this.gameObject.SetActive(status);
    }
}
