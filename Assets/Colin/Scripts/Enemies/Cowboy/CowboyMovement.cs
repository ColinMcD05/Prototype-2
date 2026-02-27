using UnityEngine;
using UnityEngine.AI;

public class CowboyMovement : MonoBehaviour
{
    // Get Cowboy components
    [Header("Cowboy Components")]
    [SerializeField] NavMeshAgent agent;

    // Get other GameObject components
    private GameObject player;

    // Mutable Variables
    [Header("Mutable Variables")]
    public float enemySpeed = 5;

    void Start()
    {
        player = GameObject.Find("Player");

        // Set agent speed equal to the speed of player
        agent.speed = enemySpeed;
        agent.updateRotation = false;
    }

    void Update()
    {
        // Setting destination of Cowboy to current position of the player
        agent.SetDestination(player.transform.position);
    }
}
