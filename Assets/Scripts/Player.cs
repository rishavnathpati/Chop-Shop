using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        var inputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W)) inputVector.y += 1;
        if (Input.GetKey(KeyCode.S)) inputVector.y -= 1;
        if (Input.GetKey(KeyCode.A)) inputVector.x -= 1;
        if (Input.GetKey(KeyCode.D)) inputVector.x += 1;

        inputVector = inputVector.normalized;
        
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * (Time.deltaTime * 5);
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * 10);
        // Debug.Log(inputVector);
    }
}