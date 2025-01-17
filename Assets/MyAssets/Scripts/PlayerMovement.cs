using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput = new Vector2();


    void Update()
    {
        print("I am moving:" + moveInput);
        Vector3 adjustedMovement = new Vector3(moveInput.x, 0f, moveInput.y);
        transform.Translate(adjustedMovement * Time.deltaTime,Space.World);
        RotatePlayer(adjustedMovement);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void RotatePlayer(Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
