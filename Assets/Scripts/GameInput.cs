using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
    }

    /// <summary>
    ///     Gets the normalized movement vector from the PlayerInputActions.
    /// </summary>
    /// <returns>Normalized Vector2 representing player input.</returns>
    public Vector2 GetMovementVectorNormalised()
    {
        // Reading the value from the PlayerInputAction and normalizing it
        var inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>().normalized;

        return inputVector;
    }
}