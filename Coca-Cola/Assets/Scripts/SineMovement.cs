using UnityEngine;

public class SineMovement : MonoBehaviour
{
    [SerializeField] private float amp;
    [SerializeField] private float freq;

    [SerializeField] private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;    
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float _time = Time.deltaTime;
        float _offset = amp * Mathf.Sin(2* Mathf.PI * freq * _time);

        transform.position = initialPosition + new Vector3(_offset,0,0);
    }
}
