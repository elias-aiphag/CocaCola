using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [Header("objects")]
    [SerializeField] private GameObject staticCanvas;
    [SerializeField] private GameObject target;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        target.SetActive(false);
    }

    public void Set_Enable_target(bool s)
    {
        bool status = s;
        target.gameObject.SetActive(status);
    }
}