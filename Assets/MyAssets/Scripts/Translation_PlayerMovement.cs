using UnityEngine;
using UnityEngine.InputSystem;

public class Translation_PlayerMovement : MonoBehaviour
{
    Vector2 moveInput = new Vector2();
    Camera cam => Camera.main;
    bool isMoving = false;
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float JumpForce = 10f;
    [SerializeField] int JumpLimit = 2;
    int jumpCount = 0;
    
    
    //float usnigned { get { return usnigned; } set { usnigned = Mathf.Abs(value); } }

    void Update()
    {
        Vector3 getMoveDirection = MoveDirection();
        MovePlayer(getMoveDirection);
        if (isMoving) RotatePlayer(getMoveDirection);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        /*  if (moveInput.x != 0 || moveInput.y != 0)
          {
              isMoving = true;
          }
          else
          {
              isMoving = false;
          }*/

        //We kunnen de if statement hierboven compacten met een ternary operator tot een singl line;
        //De waarde van isMoving is dus true wanneer eender welkek nop nog ingedrukt blijft.
        isMoving = moveInput.x != 0 || moveInput.y != 0;
        print(isMoving);

    }

    public void OnJump(InputValue value)
    {
        bool getJump = value.isPressed;
        bool isGrounded = GroundDetection.instance.IsGrounded(transform.position);
        
        if ((getJump && isGrounded) || (getJump && jumpCount <= JumpLimit))
        {
            jumpCount++;
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        else if (isGrounded)
        {
            jumpCount = 0;
        }
        //if (getGrounded) jumpCount = 0;
    }


    Vector3 CameraAdjustedVector(Vector3 moveDirection)
    {
        Vector3 forward = cam.transform.forward * moveDirection.z;
        Vector3 right = cam.transform.right * moveDirection.x;
        Vector3 combinedDirection = forward + right;
        Vector3 finalDirection = new Vector3(combinedDirection.x, 0f, combinedDirection.z);
        return finalDirection;
    }

    Vector3 MoveDirection()
    {
        Vector3 adjustedMovement = new Vector3(moveInput.x, 0f, moveInput.y);
        Vector3 moveDirection = CameraAdjustedVector(adjustedMovement);
        return moveDirection;
    }

    void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
    void RotatePlayer(Vector3 direction)
    {
        if (direction == Vector3.zero) return;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
