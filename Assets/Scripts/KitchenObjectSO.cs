using UnityEngine;

[CreateAssetMenu(fileName = "KitchenObject", menuName = "KitchenObject")]
public class KitchenObjectSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public string objectName;
}