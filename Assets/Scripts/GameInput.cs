using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Interact.performed += InteractOnPerformed;
    }

    // Event handler for the Interact action
    public event EventHandler OnInteractAction;

    /// <summary>
    ///     Invokes the OnInteractAction event.
    /// </summary>
    /// <param name="obj"> InputAction.CallbackContext </param>
    private void InteractOnPerformed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    ///     Gets the normalized movement vector from the PlayerInputActions.
    /// </summary>
    /// <returns>Normalized Vector2 representing player input.</returns>
    public Vector2 GetMovementVectorNormalised()
    {
        // Reading the value from the PlayerInputAction and normalizing it
        Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>().normalized;

        return inputVector;
    }
}