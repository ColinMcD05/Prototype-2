using Unity.VisualScripting;
using UnityEngine;

public class Cart : MonoBehaviour
{
    // Mutable ariabels in inspector
    [Header("Mutable Variables")]
    public Transform stopPoint;
    public float cartSpeed;

    private void OnEnable()
    {
        Invoke("Disable", 3);
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(stopPoint.position.x, transform.position.y, transform.position.z), cartSpeed * Time.deltaTime);
        Debug.Log("Moving");
    }

    private void Disable()
    {
        enabled = false;
    }
}
