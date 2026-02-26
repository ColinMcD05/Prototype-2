using Unity.VisualScripting;
using UnityEngine;

public class Cart : MonoBehaviour
{
    // Mutable ariabels in inspector
    [Header("Mutable Variables")]
    public float stopPoint;
    public float cartSpeed;

    public void Move()
    {
        Vector3.MoveTowards(transform.position, new Vector3(stopPoint, transform.position.y, transform.position.z), cartSpeed * Time.deltaTime);
        Debug.Log("Moving");
    }
}
