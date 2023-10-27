using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ARManager : MonoBehaviour
{
    public static ARManager ins;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI helpText;
    [SerializeField] private TextMeshProUGUI audioClipDurationText;
    [SerializeField] private Button scanButton;
    [Header("AR")]
    [SerializeField] private ARTrackedImageManager imageManager;
    [Header("Estaciones")]
    [SerializeField] private List<Estacion> estaciones;

    [SerializeField] private int _counter = 0;

    void Awake()
    {
        Init();

        Set_Enabled_ImageManager(false);
        Set_Text_HelpText("Precione el boton 'activate'");
    }

    private void Init()
    {
        if(ins == null)
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void Set_Enabled_ImageManager(bool status)
    {
        imageManager.enabled = status;
        Debug.Log("Image Manager Set Enabled : " + status);
    }

    public void Set_Text_HelpText(string s)
    {
        string message = s;
        helpText.text = message;
    }

    public void Set_Text_AudioClipDuration(string s)
    {
        string message = s;
        audioClipDurationText.text = message;
    }

    public void Set_ScanButton(bool s)
    {
        bool status = s;
        scanButton.interactable = status;
    }

    public void Next()
    {
        Active_One_Estaciones(_counter);
        
        _counter ++;
        
        if(_counter == 1)
        {
            Set_Text_HelpText("ESCANEA EL LOGO");
            Set_ScanButton(true);
        }
        
        if(_counter == 2)
        {
            Set_Text_HelpText("MIRA EL VIDEO");
            Set_ScanButton(false);
        }
        else
        {
            return;
        }
        
    }

    private void Active_One_Estaciones(int i)
    {
        Deactivate_All_Estaciones();
        estaciones[i].gameObject.SetActive(true);
    }

    private void Deactivate_All_Estaciones()
    {
        foreach(Estacion e in estaciones)
        {
            e.gameObject.SetActive(false);
        }
    }
}
