using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //movement variables
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public Transform orientation;
    public InputActionReference move;
    public InputActionReference sprint;

    bool playerPressingSprint = false;

    //Ground checking variables
    private float playerHeight = 2;
    public LayerMask isGroundCheck;
    bool grounded;


    //input variables
    private float horizontalInput;
    private float verticalInput;
    private Vector2 moveInputGetVector;
    private Vector3 movementDirection;
    //stops player from sliding on the ground like it's ice. Basically adds friction. 
    [SerializeField] private float damping;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, isGroundCheck); 
        Input();
        sprinting();
        //sprinting();
        rb.linearDamping = damping;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    //takes the input action, reads it into a vector2, so that it can be called to feed into floats for hori and vert movement. 
    private void Input()
    {
        moveInputGetVector = move.action.ReadValue<Vector2>();
        horizontalInput = moveInputGetVector.x;
        verticalInput = moveInputGetVector.y;
    }

    private void sprinting()
    {
        if (sprint.action.IsPressed() && grounded)
        {
            moveSpeed = sprintSpeed;
        } else if (grounded && !sprint.action.IsPressed())
        {
            moveSpeed = walkSpeed;
        }
        //else
        //{
           //use if needed a different speed for falling
        //}
    }
    private void MovePlayer()
    {
        //movement direction, gets the direction the player should be moving when going forward. 
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //moves player
        rb.AddForce(movementDirection.normalized * moveSpeed, ForceMode.Force);
    }


}
