using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
    //Camera settings
    public float xCamSensitivity;
    public float yCamSensitivity;
    private float xCamTurning;
    private float yCamTurning;
    //controls players orientation
    public Transform orientation;

    [SerializeField] InputActionReference mouse;
    private Vector2 mouseInputGetVector;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //get mouse or right stick input, seperate to 2 floats for x and y. 
        mouseInputGetVector = mouse.action.ReadValue<Vector2>();
        float mouseX = mouseInputGetVector.x * Time.deltaTime * xCamSensitivity;
        float mouseY = mouseInputGetVector.y * Time.deltaTime * yCamSensitivity;
        //use inputs to turn
        xCamTurning += mouseX;
        yCamTurning -= mouseY;
        yCamTurning = Mathf.Clamp(yCamTurning, -90f, 90f);
        transform.rotation = Quaternion.Euler(yCamTurning, xCamTurning, 0);
        orientation.rotation = Quaternion.Euler(0, xCamTurning, 0);
    }



}
