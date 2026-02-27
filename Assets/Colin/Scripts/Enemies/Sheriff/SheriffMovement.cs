using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class SheriffMovement : MonoBehaviour
{
    //animation - jose
    [SerializeField] private Animator animator;

    // Get Sheriffs Components
    [Header("Sheriffs Components")]
    [SerializeField] NavMeshAgent agent;

    // Get Seperate GameObject/Scripts
    private GameObject player;

    // Mutable Variables
    [Header("Mutable Variables")]
    public Transform[] waypoints;
    public float patrolSpeed;
    public float chaseSpeed;

    // Mutable Variables that get referenced/changed in script
    [HideInInspector]public bool seePlayer;
    [HideInInspector]public bool sawPlayer;
    public float waitCounter;
    int currentWaypointIndex;
    int lookDirection = 1;
    Quaternion lookRotation;

    // Immutable variables
    float reachDistance = 0.1f;
    public float lookAroundTimer = 4;

    private void OnEnable()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (seePlayer)
        {
            Chase();
            animator.SetBool("isRunning", true);
        }
        else if (sawPlayer)
        {
            LookAround();
            animator.SetBool("isRunning", false);
        }
        else
        {
            Patrol();
            animator.SetBool("isRunning", false);
        }
    }

    void Chase()
    {
        agent.SetDestination(player.transform.position);
    }

    void Patrol()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            return;
        }

        if (waitCounter > 0f)
        {
            waitCounter -= Time.deltaTime;
            if (transform.rotation != lookRotation)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5 * Time.deltaTime);
            }
            else
            {
                lookDirection *= -1;
                lookRotation *= Quaternion.Euler(0, 0, 30 * lookDirection);
            }
            return;
        }

        Transform target = waypoints[currentWaypointIndex];

        if ((new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(target.position.x, 0, target.position.z)).sqrMagnitude < reachDistance * reachDistance)
        {
            int nextWaypointIndex = UnityEngine.Random.Range(0, waypoints.Length);
            while(currentWaypointIndex == nextWaypointIndex)
            {
                nextWaypointIndex = UnityEngine.Random.Range(0, waypoints.Length);
            }
            currentWaypointIndex = nextWaypointIndex;
            lookRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
            waitCounter = 5;
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }

    void LookAround()
    {
        if ((new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(agent.destination.x, 0, agent.destination.z)).sqrMagnitude < reachDistance * reachDistance)
        {
            if (lookAroundTimer > 0f)
            {
                lookAroundTimer -= Time.deltaTime;
                if (transform.rotation != lookRotation)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5 * Time.deltaTime);
                }
                else
                {
                    lookDirection *= -1;
                    lookRotation *= Quaternion.Euler(0, 0, 45 * lookDirection);
                }
                return;
            }
            else
            {
                sawPlayer = false;
                lookAroundTimer = 4;
            }
        }
        else
        {
            lookRotation = transform.rotation * Quaternion.Euler(0, 45, 0);
        }
    }
}
