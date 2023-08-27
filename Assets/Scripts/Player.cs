using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameInput gameInput; // The game input that controls the player.

    [SerializeField] [Range(1, 10)]
    private float speed = 5; // Speed of the player (Adjustable within range from Inspector).

    [SerializeField] private LayerMask counterLayerMask; // LayerMask to check for counters.

    private bool _isWalking; // Flag to check if player is walking.
    private Vector3 _lastInteractDir; // The last direction the player was facing when interacting.

    private void Start()
    {
        gameInput.OnInteractAction += GameInputOnOnInteractAction;
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    private void GameInputOnOnInteractAction(object sender, EventArgs e)
    {
        // Fetch the normalized movement vector from the associated input system.
        var inputVector = gameInput.GetMovementVectorNormalised();

        // Form the movement direction vector with the inputVector.
        var moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDir == Vector3.zero)
            moveDir = _lastInteractDir;
        else
            _lastInteractDir = moveDir;
        const float interactDistance = 2f;
        if (Physics.Raycast(transform.position, moveDir, out var raycastHit, interactDistance, counterLayerMask))
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
                clearCounter.Interact();
    }

    /// <summary>
    ///     Function to check if the player is walking
    /// </summary>
    /// <returns></returns>
    public bool IsWalking()
    {
        return _isWalking;
    }

    /// <summary>
    /// </summary>
    private void HandleInteractions()
    {
        // Fetch the normalized movement vector from the associated input system.
        var inputVector = gameInput.GetMovementVectorNormalised();

        // Form the movement direction vector with the inputVector.
        var moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDir == Vector3.zero)
            moveDir = _lastInteractDir;
        else
            _lastInteractDir = moveDir;
        const float interactDistance = 2f;
        if (Physics.Raycast(transform.position, moveDir, out var raycastHit, interactDistance, counterLayerMask))
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                // clearCounter.Interact();
            }
    }

    /// <summary>
    ///     Handles the movement of the player based on the input from the game's input system. It calculates a
    ///     directional vector for the movement, checks if the planned movement would result in a collision and alters
    ///     the direction if so. The player's position is updated as per the final calculated movement vector.
    /// </summary>
    private void HandleMovement()
    {
        // Fetch the normalized movement vector from the associated input system.
        var inputVector = gameInput.GetMovementVectorNormalised();

        // Form the movement direction vector with the inputVector.
        var moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        // Define the player's capsule shape for Physic's CapsuleCast and the distance to move on this frame.
        const float playerRadius = .7f;
        const float playerHeight = 2f;
        var moveDistance = Time.deltaTime * speed;

        // Execute a CapsuleCast to check if the calculated moment would result in a collision.
        var canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
            playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            // Cannot move forward, try left or right

            // Create a new movement direction only considering X (left or right).
            var moveDirX = new Vector3(moveDir.x, 0, 0).normalized;

            // Try a CapsuleCast with the new direction
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                // If successful, update movement direction
                moveDir = moveDirX;
            }
            else
            {
                // Else, create a new movement direction only considering Z (forward or backward)
                var moveDirZ = new Vector3(0, 0, moveDir.z).normalized;

                // Try a CapsuleCast with the new direction
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                    playerRadius, moveDirZ, moveDistance);
                if (canMove)
                    // If successful, update movement direction
                    moveDir = moveDirZ;
            }
        }

        // Move the player if no obstructions are found
        if (canMove) transform.position += moveDir * moveDistance;

        // Set the walking state based on whether there's any movement or not
        _isWalking = moveDir != Vector3.zero;

        // Smoothly rotate the player to face the moving direction
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * 10);
    }
}