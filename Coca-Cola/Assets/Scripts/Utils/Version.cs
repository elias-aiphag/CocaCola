using TMPro;
using UnityEngine;

public class Version : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textDisplay;

    void Start()
    {
        string version = Application.version;
        _textDisplay.text = version;
    }
}
