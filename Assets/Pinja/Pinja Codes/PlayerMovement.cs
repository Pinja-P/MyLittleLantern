using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playerRB;

    //Movement
    float moveSpeed;
    public float walkSpeed = 5f;
    private Vector2 moveInput;

    //Sneak
    public float sneakSpeed = 2f;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        moveSpeed = walkSpeed;
    }

    void Update()
    {
        playerRB.linearVelocity = moveInput * moveSpeed;

    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Sneak(InputAction.CallbackContext context)
    {
        if (context.performed)
         {
             moveSpeed = sneakSpeed;
             Debug.Log("Sneaking");
         }

        if (context.canceled)
        {
            moveSpeed = walkSpeed;
            Debug.Log("Walking");
        }

        /* if (Keyboard.current.leftShiftKey.isPressed)
         {
             moveSpeed = sneakSpeed;
             Debug.Log("Sneaking");
         } */

        /* if (Input.GetKey(KeyCode.LeftShift))
         {
             moveSpeed = sneakSpeed;
             Debug.Log("Sneaking");
         } */

    }
}
