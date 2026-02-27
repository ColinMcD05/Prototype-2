using Unity.Transforms;
using Unity.VisualScripting;
using UnityEngine;

public class TornadoMovement : MonoBehaviour
{
    // Mutable Variable
    [Header("Mutable Variable")]
    public float moveSpeed;
    [SerializeField] Transform[] waypoints;

    // Mutable Variables within scripts only
    int currentWaypoint;

    // Immutable Variables
    float reachDistance = 0.1f;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            return;
        }

        Transform target = waypoints[currentWaypoint];

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, target.position.z), moveSpeed * Time.deltaTime);

        if ((new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(target.position.x, 0, target.position.z)).sqrMagnitude < reachDistance * reachDistance)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }
}
