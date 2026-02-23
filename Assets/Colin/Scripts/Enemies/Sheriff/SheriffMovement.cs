using UnityEngine;
using UnityEngine.AI;

public class SheriffMovement : MonoBehaviour
{
    // Get Sheriffs Components
    [Header("Sheriffs Components")]
    [SerializeField] NavMeshAgent agent;

    // Get Seperate GameObject/Scripts
    private GameObject player;

    // Mutable Variables
    [Header("Mutable Variables")]
    public float patrolSpeed;
    public float chaseSpeed;

    // Mutable Variables that get referenced/changed in script
    [HideInInspector]public bool seePlayer;
    [HideInInspector]public bool sawPlayer;


}
