using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallVideo : MonoBehaviour
{
    public void Set_Enable_smallVideo(bool _b)
    {
        bool status = _b;
        this.gameObject.SetActive(status);
    }
}
