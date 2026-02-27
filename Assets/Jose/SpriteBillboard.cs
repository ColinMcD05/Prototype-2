using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{

    [SerializeField] private Camera _mainCamera;

    // Update is called once per frame
    private void LateUpdate()
    {
        /*Vector3.cameraPosition
            = _mainCamera.transform.position;
        cameraPosition.y
            = transform.position.y;
        transform.LookAt(cameraPosition);
        transform.Rotate(0f, 180f, 0f);
        */
    }
}
