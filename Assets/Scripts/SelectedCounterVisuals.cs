using UnityEngine;

public class SelectedCounterVisuals : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject selectedVisualGameObject;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.SelectedCounterChangedEventArgs e)

    {
        if (e.SelectedCounter == clearCounter)
        {
            Debug.Log("Selected");
            selectedVisualGameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Deselected");
            selectedVisualGameObject.SetActive(false);
        }
    }
}