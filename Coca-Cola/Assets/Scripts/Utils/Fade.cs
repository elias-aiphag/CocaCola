using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private RawImage image;
    [SerializeField] private CanvasRenderer canvasRenderer;
    [SerializeField] private float _time;

    void Start()
    {
        StartCoroutine(FadeRawImage());
    }

    IEnumerator FadeRawImage()
    {
        canvasRenderer.SetAlpha(0f);
        yield return new WaitForSeconds(_time);
        canvasRenderer.SetAlpha(1f);
    }
}
