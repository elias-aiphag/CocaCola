using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWithTimer : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float timer;

    private void Start() {
        Invoke(nameof(Clear),timer);
    }

    private void Clear() {
        target.gameObject.SetActive(false);
    }
}
