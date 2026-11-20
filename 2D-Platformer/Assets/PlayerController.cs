using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player stats")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheckPos;

    Vector2 moveVector;
    Rigidbody2D playerRb;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isGrounded)
            {
                Jump();
            }
            
            Debug.Log("Pressed Jump");

        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        playerRb.linearVelocity = new Vector2(moveVector.x * moveSpeed, playerRb.linearVelocity.y);
        CheckForGround();
    }

    
    void Jump()
    {
        playerRb.linearVelocityY = 0;
        playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }


    void CheckForGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, 0.2f, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        if (isGrounded)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
    }
}