using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = transform;
    }

    private void Update()
    {
        var inputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W)) inputVector.y += 1;
        if (Input.GetKey(KeyCode.S)) inputVector.y -= 1;
        if (Input.GetKey(KeyCode.A)) inputVector.x -= 1;
        if (Input.GetKey(KeyCode.D)) inputVector.x += 1;

        inputVector = inputVector.normalized;
        
        var moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        
        _playerTransform.position += moveDir * (Time.deltaTime * 5);
        transform.forward = Vector3.Slerp(_playerTransform.forward, moveDir, Time.deltaTime * 10);
    }
    
    public bool IsWalking()
    {
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
    }
}