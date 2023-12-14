using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    [SerializeField] [Range(1, 5)] private float speed = 5f;
    private PlayerInputActions _playerInputActions;
    private Transform _playerTransform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GetComponent<PlayerInput>();
        _playerTransform = transform;

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = _playerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 moveDir = new(inputVector.x, 0, inputVector.y);

        _playerTransform.position += moveDir * (Time.deltaTime * speed);
        transform.forward = Vector3.Slerp(_playerTransform.forward, moveDir, Time.deltaTime * 10);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("Jump" + context);
            _rigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }
    }
}