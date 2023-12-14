using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private Transform tomatoPrefab;
    [SerializeField] private Transform counterTopPointReference;

    public void Interact()
    {
        Debug.Log("Interact! ");
        Transform tomatoTransform = Instantiate(tomatoPrefab, counterTopPointReference);
        tomatoTransform.localPosition = Vector3.zero;
    }
}