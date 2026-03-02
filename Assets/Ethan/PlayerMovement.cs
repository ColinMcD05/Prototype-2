using UnityEngine;
using UnityEngine.UI;
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


    //stamina variables
    public Slider staminaSlider;
    private float currentStam;
    public float maxStam;


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
        currentStam = maxStam;  
        if (staminaSlider != null)
        {
            staminaSlider.maxValue = maxStam;
            staminaSlider.value = currentStam;
        }
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, isGroundCheck); 
        Input();
        sprinting();
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
        //if sprinting and grounded and have stam, change stamina and ui, set new speed. 
        if (sprint.action.IsPressed() && grounded)
        {
            if (currentStam > 0)
            {
                currentStam--;
            }
            Debug.Log(currentStam);
            staminaSlider.value = currentStam;
            moveSpeed = sprintSpeed;
        } else if (grounded && !sprint.action.IsPressed())
        {
            if (currentStam < maxStam)
            {
                currentStam++;
            }
            Debug.Log(currentStam);
            staminaSlider.value = currentStam;
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
