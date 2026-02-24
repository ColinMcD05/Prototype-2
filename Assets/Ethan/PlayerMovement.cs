using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform orientation;
    public InputActionReference move;

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
        Input();
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

    private void MovePlayer()
    {
        //movement direction, gets the direction the player should be moving when going forward. 
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //moves player
        rb.AddForce(movementDirection.normalized * moveSpeed, ForceMode.Force);
    }
}
