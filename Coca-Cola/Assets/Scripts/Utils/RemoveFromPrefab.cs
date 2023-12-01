using UnityEngine;

public class RemoveFromPrefab : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private Transform objectiveObject;

    void Start()
    {
        transform.position = targetObject.position;
        Change();
        
    }

    public void Change()
    {
        targetObject.SetParent(objectiveObject);
    }
}
