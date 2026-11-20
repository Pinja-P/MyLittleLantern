using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D playerRB;
    public CinemachineCamera CMCameraMain;
    public CinemachineCamera CMCameraStill;

    //Movement
    float moveSpeed;
    public float walkSpeed = 5f;
    private Vector2 moveInput;

    //Sneak
    public float sneakSpeed = 2f;
    
    //BatCarry
    public bool batCarry = false;
    public GameObject batCarrier;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        moveSpeed = walkSpeed;
    }

    void Update()
    {
        playerRB.linearVelocity = moveInput * moveSpeed;
        
        BatCarry();
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

    }

    public void BatCarry()
    {
        if (batCarry)
        {
            transform.position = batCarrier.transform.position;
            return;
        }      
    }
}
