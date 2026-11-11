using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player stats")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    Vector2 moveVector;
    Rigidbody2D playerRb;
    private void start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Jump");

        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        playerRb.linearVelocity = new Vector2(moveVector.x * moveSpeed, playerRb.linearVelocity.y);
    }
    
    void Jump()
    {
        playerRb.linearVelocityY = 0;
        playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}
