using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveQRScnner : MonoBehaviour
{
    private GameObject _scanner;

    void Start()
    {
        Get_Component();
        Component_Status(false);
    }

    private void Get_Component()
    {
        GameObject _aux = GameObject.Find("Canvas_Static_UI/Scanner");
        _scanner = _aux;
    }

    private void Component_Status(bool status)
    {
        bool b = status;
        _scanner.gameObject.SetActive(b);
    }
}