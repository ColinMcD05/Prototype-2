using Unity.VisualScripting;
using UnityEngine;

public class Cart : MonoBehaviour
{
    // Mutable ariabels in inspector
    [Header("Mutable Variables")]
    public float stopPoint;
    public float cartSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3.MoveTowards(transform.position, new Vector3(stopPoint, transform.position.y, transform.position.z), cartSpeed * Time.deltaTime);
        }
    }
}
