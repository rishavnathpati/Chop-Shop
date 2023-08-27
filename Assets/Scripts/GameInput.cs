using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalised()
    {
        var inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector =
            inputVector.normalized; // we can normalize the vector here or in the PlayerInputAction asset using a processor (normalise vector2)
        return inputVector;
    }
}