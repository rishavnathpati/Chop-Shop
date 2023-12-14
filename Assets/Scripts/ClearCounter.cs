using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObject;
    [SerializeField] private Transform counterTopPointReference;

    public void Interact()
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObject.prefab, counterTopPointReference);
        kitchenObjectTransform.localPosition = Vector3.zero;

        Debug.Log("Interact! " + kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO());
    }
}