using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //Apparently moving the camera with the player's rigidbody can cause a lot of bugs. 
    //This script moves the empty Camera holder, which is a parent of Main camera, so it moves too. 
    //I don't know why this gets around the bugs.
    public Transform cameraPosition;

    private void Update()
    {
        transform.position = cameraPosition.position;
    }

}
