using UnityEngine;
using UnityEngine.AI;

public class SheriffVision : MonoBehaviour
{
    // Sheriff Components
    [Header("Sheriff Components")]
    [SerializeField] NavMeshAgent agent;
    [SerializeField] SheriffMovement sheriffMovement;

    // Get Other Components
    Transform player;

    // Mutable variables
    [Header("Mutable Variables")]
    public float visionRange;
    [Range(1, 360)] public float detectionAngle;
    [Range(180, 360)] public float peripheryVision;

    // Immutable variables
    LayerMask visionMasks;
    LayerMask playerMask;

    void Awake()
    {
        player = GameObject.Find("Player").transform;

        visionMasks = LayerMask.GetMask("Player", "Default");
        playerMask = LayerMask.GetMask("Player");
    }

    private void Update()
    {
        Debug.Log(CheckIsNotHidden());
        Debug.Log(CheckInFieldOfView());
    }

    // Function to check if enemy can see player
    bool CheckIsNotHidden()
    {
        Vector3 direction = player.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, visionRange))
        {
            return hit.collider.CompareTag("Player");
        }
        return false;
    }

    bool CheckInFieldOfView()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, visionRange, playerMask);
        if (rangeCheck != null)
        {
            Vector3 directionToTarget = (player.transform.position - transform.position).normalized;
            foreach (Collider collision in rangeCheck)
            {
                if (collision.CompareTag("Player"))
                {
                    if (Vector3.Angle(transform.forward, directionToTarget) <= detectionAngle * 0.5f)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    bool Found()
    {
        return CheckInFieldOfView() && CheckIsNotHidden();
    }
}
